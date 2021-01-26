using System;
using System.IO;

namespace FileWOrk2_Sizer
{
	public static class DirectoryExtension
	{
		public static string exceptedFolders = "";
		static int deep = 0; //счётчик погружения
		/// <summary>
		/// рекурсивный подсчёт размера файлов в текущеё папке и всех её подкаталогах
		/// </summary>
		/// <param name="d"></param>
		/// <returns></returns>
		public static long DirSize(DirectoryInfo d)
		{
			long size = 0;
			try
			{
				FileInfo[] files = d.GetFiles();
				foreach (FileInfo f in files)
				{
					size += f.Length;
				}

				DirectoryInfo[] dirs = d.GetDirectories();
				foreach (DirectoryInfo dir in dirs)
				{
					size += DirSize(dir);
				}
			}
			catch (Exception e)
			{
				exceptedFolders += d.FullName + "\n";
			}
			return size;
		}

		/// <summary>
		/// вывод содержимого папок с указанием размера файлов
		/// </summary>
		/// <param name="d"></param>
		public static void SizeExplorer(DirectoryInfo d)
		{
			deep++; // визуализация погружения при выводе имени файла/папки
			string result = "";
			string tab = new String(' ', deep * 2); // отступ
			// обход каталогов
			try
			{
				DirectoryInfo[] dirs = d.GetDirectories();
				foreach (DirectoryInfo dir in dirs)
				{
					result = String.Format("{0,-60}"
						, String.Format("{0}[{1}]", tab, dir.Name)
					);
					Console.WriteLine(result);
					SizeExplorer(dir);
				}

				// переходим к файлам
				FileInfo[] fs = d.GetFiles();
				foreach (FileInfo f in fs)
				{
					result = String.Format("{0,-40} {1,20:### ### ### ### ##0}"
						, tab + f.Name
						, f.Length
					);
					Console.WriteLine(result);
				}
			}
			catch (Exception e)
			{
				Console.WriteLine("Папка не сдаётся по причине {0}", e.Message);
			}
			deep--;
		}
	}
}
