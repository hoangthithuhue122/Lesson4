using System.Text.Json;

namespace DevmasterTrainingManagement.Infrastructure.Data;

public static class JsonStorage
{
    // Hàm lưu file JSON
    public static void Save<T>(string filePath, T data)
    {
        var options = new JsonSerializerOptions { WriteIndented = true };
        string jsonString = JsonSerializer.Serialize(data, options);
        File.WriteAllText(filePath, jsonString);
    }

    // Hàm đọc file JSON khi khởi động
    public static T Load<T>(string filePath) where T : new()
    {
        if (!File.Exists(filePath))
        {
            return new T(); // Nếu chưa có file thì trả về danh sách rỗng
        }
        string jsonString = File.ReadAllText(filePath);
        return JsonSerializer.Deserialize<T>(jsonString) ?? new T();
    }
}