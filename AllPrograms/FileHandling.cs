using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using CsvHelper;
using System.Globalization;

namespace AllPrograms
{
    public class FileHandling
    {
        public FileHandling() { }

        public void CreateStundentDirectory()
        {
            string folderpath = "C://temp//";

            string dirName = "Student";

            string DirectoryPath = Path.Combine(folderpath, dirName);
            var student = new Student();
            var studet_data = student.ReadCsvData();

            // Create the directory if it doesn't exist
            if (!Directory.Exists(DirectoryPath))
            {
                Directory.CreateDirectory(DirectoryPath);
                Console.WriteLine($"Directory '{dirName}' created successfully.");

                foreach( var std in studet_data)
                {
                    string filename = $"{std.StudentName}.txt";
                    string file_path = Path.Combine(DirectoryPath, filename);
                    using (StreamWriter sw = new StreamWriter(file_path))
                    {

                        sw.WriteLine($"****** {std.StudentName} Details *********");
                        sw.WriteLine($"Student Name : {std.StudentName}");
                        sw.WriteLine($"Student FatherName : {std.Father}");
                        sw.WriteLine($"Student City : {std.City}");
                        sw.WriteLine($"Student Grade : {std.Grade}");
                    }
                    
                }

                

            }

            ViewDirectorydetails(DirectoryPath);
            ViewFilesInfo(DirectoryPath);
        }

        static void ViewDirectorydetails(string directoryPath)
        {          

            try
            {
                DirectoryInfo dirInfo = new DirectoryInfo(directoryPath);

                Console.WriteLine("Directory Name: " + dirInfo.Name);
                Console.WriteLine("Creation Time: " + dirInfo.CreationTime);
                Console.WriteLine("Last Access Time: " + dirInfo.LastAccessTime);
                Console.WriteLine("Last Write Time: " + dirInfo.LastWriteTime);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred: " + ex.Message);
            }
        }

        public void ViewFilesInfo(string path)
        {
            foreach (string file in Directory.GetFiles(path))
            {
                Console.WriteLine("File: " + file);
                FileInfo fileInfo = new FileInfo(Path.Combine(path,file));

                Console.WriteLine("File Name: " + fileInfo.Name);
                Console.WriteLine("File Size: " + fileInfo.Length + " bytes");
                Console.WriteLine("Creation Time: " + fileInfo.CreationTime);
                Console.WriteLine("Last Access Time: " + fileInfo.LastAccessTime);
                Console.WriteLine("Last Write Time: " + fileInfo.LastWriteTime);
            }
        }

        }

    public class Student
    {             

        public string StudentName { get; set; }
        public string City { get; set; }
        public string Father { get; set; }
        public string Grade { get; set; }

        public List<Student> ReadCsvData()
        {
            string ditectoty_path = Directory.GetCurrentDirectory();
            string file_path = $"{ditectoty_path.Split(new[] { Task_Constants.delimeter }, StringSplitOptions.None)[0]}//AllPrograms//student.csv";            
            List<Student> students = new List<Student>();
            using (var reader = new StreamReader(file_path))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                students = csv.GetRecords<Student>().ToList();

            }

            return students;

        }
    }
}
