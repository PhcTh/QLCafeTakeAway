using System.Data;
using Microsoft.Data.SqlClient;

namespace backend_csharp.Data;

public static class SqlHelpers
{
    public static void AddParam(this SqlCommand command, string name, object? value)
    {
        command.Parameters.AddWithValue(name, value ?? DBNull.Value);
    }
// Các hàm đọc dữ liệu từ SqlDataReader với xử lý giá trị null và kiểu dữ liệu khác nhau
    public static string GetString(this SqlDataReader reader, string name)
    {
        var value = reader[name];
        return value == DBNull.Value ? string.Empty : Convert.ToString(value) ?? string.Empty;
    }

    public static string? GetNullableString(this SqlDataReader reader, string name)
    {
        var value = reader[name];
        return value == DBNull.Value ? null : Convert.ToString(value);
    }

    public static int GetInt(this SqlDataReader reader, string name)
    {
        return Convert.ToInt32(reader[name]);
    }

    public static decimal GetDecimal(this SqlDataReader reader, string name)
    {
        return Convert.ToDecimal(reader[name]);
    }

    public static DateOnly GetDateOnly(this SqlDataReader reader, string name)
    {
        return DateOnly.FromDateTime(Convert.ToDateTime(reader[name]));
    }

    public static TimeOnly GetTimeOnly(this SqlDataReader reader, string name)
    {
        var value = reader[name];
        return value switch
        {
            TimeSpan span => TimeOnly.FromTimeSpan(span),
            DateTime dateTime => TimeOnly.FromDateTime(dateTime),
            _ => TimeOnly.Parse(Convert.ToString(value) ?? "00:00:00")
        };
    }
// Những hàm này đọc dữ liệu từ SqlDataReader rồi đổi về kiểu c# phù hợp
    public static async Task<List<T>> QueryAsync<T>(
        SqlConnection connection,
        string sql,
        Action<SqlCommand>? bind,
        Func<SqlDataReader, T> map,
        SqlTransaction? transaction = null)
    {
        await using var command = new SqlCommand(sql, connection, transaction);
        bind?.Invoke(command);

        var rows = new List<T>();
        await using var reader = await command.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            rows.Add(map(reader));
        }

        return rows;
    }
// Hàm ghi dữ liệu
    public static async Task<int> ExecuteAsync(
        SqlConnection connection,
        string sql,
        Action<SqlCommand>? bind = null,
        SqlTransaction? transaction = null)
    {
        await using var command = new SqlCommand(sql, connection, transaction);
        bind?.Invoke(command);
        return await command.ExecuteNonQueryAsync();
    }
// Hàm lấy 1 số hoặc 1 giá trị duy nhất
    public static async Task<T?> ScalarAsync<T>(
        SqlConnection connection,
        string sql,
        Action<SqlCommand>? bind = null,
        SqlTransaction? transaction = null)
    {
        await using var command = new SqlCommand(sql, connection, transaction);
        bind?.Invoke(command);
        var value = await command.ExecuteScalarAsync();

        if (value is null || value == DBNull.Value)
        {
            return default;
        }

        return (T)Convert.ChangeType(value, typeof(T));
    }

    public static SqlParameter StructuredParam(string name, DataTable table)
    {
        return new SqlParameter(name, SqlDbType.Structured)
        {
            Value = table
        };
    }
}
