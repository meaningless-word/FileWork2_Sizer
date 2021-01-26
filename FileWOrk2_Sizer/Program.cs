using System;
using System.IO;

namespace FileWOrk2_Sizer
{
	//Напишите программу, которая считает размер папки на диске (вместе со всеми вложенными папками и файлами). 
	//На вход метод принимает URL директории, в ответ — размер в байтах.
	class Program
	{
		static void Main(string[] args)
		{
			Console.Write("Укажите путь к рабочей папке: ");
			string workPath = Console.ReadLine();

			if (Directory.Exists(workPath))
			{
				DirectoryInfo dir = new DirectoryInfo(workPath);
				DirectoryExtension.SizeExplorer(dir);

				Console.WriteLine("Общий размер папки: {0,20:### ### ### ### ##0}", DirectoryExtension.DirSize(dir));
				if (DirectoryExtension.exceptedFolders.Length > 0)
					Console.WriteLine("за исключением\n{0}", DirectoryExtension.exceptedFolders);
			}
			else
			{
				Console.WriteLine("Папка {0} не обнаружена", workPath);
			}
		}
	}
}
