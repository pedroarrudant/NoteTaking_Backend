using Application.Shared.Models;
using Application.Shared.Repositories.Interfaces;
using Dapper;

namespace Application.Shared.Repositories;

public class BasePostgresRepository<T> : IBaseRepository<T> where T : class
{
    private readonly IDbConnectionFactory _connectionFactory;

    public BasePostgresRepository(IDbConnectionFactory connectionFactory)
    {
        _connectionFactory = connectionFactory;
    }

    public async Task<IEnumerable<T>> GetAllAsync(string tableName)
    {
        using var conn = _connectionFactory.CreateConnection();
        var sql = $@"
                    SELECT 
                        id,
                        titulo,
                        descricao,
                        prioridade,
                        data_criacao AS ""DataCriacao"",
                        concluida
                    FROM {tableName}";
        return await conn.QueryAsync<T>(sql);
    }

    public async Task<T?> GetByIdAsync(string tableName, object id)
    {
        using var conn = _connectionFactory.CreateConnection();
        var sql = $@"
                    SELECT 
                        id,
                        titulo,
                        descricao,
                        prioridade,
                        data_criacao AS ""DataCriacao"",
                        concluida FROM {tableName} WHERE id = @Id";
        return await conn.QueryFirstOrDefaultAsync<T>(sql, new { Id = id });
    }

    public async Task<int> InsertAsync(string tableName, T entity)
    {
        using var conn = _connectionFactory.CreateConnection();
        var props = typeof(T).GetProperties().Where(p => p.Name.ToLower() != "id");

        var columns = string.Join(",", props.Select(p => p.Name));
        var values = string.Join(",", props.Select(p => $"@{p.Name}"));

        var sql = $"INSERT INTO {tableName} ({columns}) VALUES ({values})";
        return await conn.ExecuteAsync(sql, entity);
    }

    public async Task<int> InsertAsync(string tableName, NoteModel entity)
    {

        using var conn = _connectionFactory.CreateConnection();

        var sql = $@"
    INSERT INTO {tableName}
    (titulo, descricao, prioridade, data_criacao, concluida)
    VALUES (@Titulo, @Descricao, @Prioridade, @DataCriacao, @Concluida)
    RETURNING 
        id,
        titulo,
        descricao,
        prioridade,
        data_criacao AS ""DataCriacao"",
        concluida;";

        var newId = await conn.ExecuteScalarAsync<int>(sql, new
        {
            entity.Titulo,
            entity.Descricao,
            entity.Prioridade,
            entity.DataCriacao,
            entity.Concluida
        });

        return newId;
    }

    public async Task<int> UpdateAsync(string tableName, T entity, object id)
    {
        using var conn = _connectionFactory.CreateConnection();
        var props = typeof(T).GetProperties().Where(p => p.Name.ToLower() != "id");

        var setClause = string.Join(", ", props.Select(p => $"{p.Name} = @{p.Name}"));
        var sql = $"UPDATE {tableName} SET {setClause} WHERE id = @Id";

        var parameters = new DynamicParameters(entity);
        parameters.Add("Id", id);

        return await conn.ExecuteAsync(sql, parameters);
    }

    public async Task<NoteModel> UpdateAsync(string tableName, NoteModel entity)
    {
        using var conn = _connectionFactory.CreateConnection();

        var sql = $@"
        UPDATE {tableName}
        SET 
            titulo = @Titulo,
            descricao = @Descricao,
            prioridade = @Prioridade,
            concluida = @Concluida
        WHERE id = @Id
        RETURNING 
            id,
            titulo,
            descricao,
            prioridade,
            data_criacao AS ""DataCriacao"",
            concluida;";

        var updatedNote = await conn.QuerySingleOrDefaultAsync<NoteModel>(sql, new
        {
            entity.Titulo,
            entity.Descricao,
            entity.Prioridade,
            entity.Concluida,
            entity.Id
        });

        return updatedNote;
    }


    public async Task<int> DeleteAsync(string tableName, object id)
    {
        using var conn = _connectionFactory.CreateConnection();
        var sql = $"DELETE FROM {tableName} WHERE id = @Id";
        return await conn.ExecuteAsync(sql, new { Id = id });
    }
}
