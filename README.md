# WpfAppSquirrelTest

Если решили выпустить обновление, то выполняем порядок дейстий:

	1. Компилируем проект в режиме Release
  
	2. Открываем NPE (NuGet Package Explorer)
  
	3. Создаём новый package - Create a new package (Ctrl + N)
  
	4. Редактируем метаданные - Edit Metadata (Ctrl + K)
  
	5. В панель Package contents создаём папку lib, в lib создаём net45, в net45 добавляем скомпилированные нами Release файлы, но без *.pdb
  
	6. Сохраняем NPE проект в директорию с проектом Visual Studio, где распологается файл *.sln (В моё случае сохранился файл с именем MyApp.1.0.0.nupkg)
  
	7. Заходим в Visual Studio, открываем Консоль диспетчера пакетов
  
	8. В Диспетчере пакетов пишем команду:
	PM> Squirrel --releasify MyApp.1.0.0.nupkg
	
	P.S.: MyApp.1.0.0.nupkg - сохраненное название файла из NPE (NuGet Package Explorer)
