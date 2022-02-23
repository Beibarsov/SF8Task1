// See https://aka.ms/new-console-template for more information


Console.WriteLine("Введите путь к требуемой для очищения папке");
string path = Console.ReadLine();

DirectoryInfo directoryInfo = new DirectoryInfo(path);

if (!Directory.Exists(path))
{
    Console.WriteLine("Неправильно задан путь к папке");
}
else
{
    try
    {


        FileInfo[] files = directoryInfo.GetFiles();
        foreach (FileInfo file in files)
        {
            Console.WriteLine(file.FullName);
            Console.WriteLine(file.LastAccessTime);
            if (DateTime.Now > file.LastAccessTime.AddMinutes(30))
            {
                Console.WriteLine("Файл давно не использовался и будет удален");
                file.Delete();
            }
        }


        DirectoryInfo[] dirs = directoryInfo.GetDirectories();
        foreach (DirectoryInfo dir in dirs)
        {
            Console.WriteLine(dir.FullName);
            Console.WriteLine(dir.LastAccessTime);
            if (DateTime.Now > dir.LastAccessTime.AddMinutes(30))
            {
                Console.WriteLine("Папка давно не использовалась и будет удалена");
                dir.Delete(true);
            }
        }
    }
    catch (Exception ex)
    {
        Console.WriteLine($"Ошибка: {ex}");
    }

}
