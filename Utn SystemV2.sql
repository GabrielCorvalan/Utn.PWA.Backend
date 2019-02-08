USE [Utn_Sys]
GO
--Careers
INSERT INTO [dbo].[Careers]([Name], [Deleted]) VALUES ('Tecnico Superior en Sistemas', 0) 
INSERT INTO [dbo].[Careers]([Name], [Deleted]) VALUES ('Tecnico Superior en Arquitectura', 0) 
INSERT INTO [dbo].[Careers]([Name], [Deleted]) VALUES ('Tecnico Superior en Infraestructura',0) 
INSERT INTO [dbo].[Careers]([Name], [Deleted]) VALUES ('Ingenieria en Informatica', 0) 

--Companies
INSERT INTO [dbo].[Companies]([Name],[Cuit],[Email],[Deleted],[Address]) 
VALUES ('Snoop Consulting','20304583829','Snoop@gmail.com',0,'Sarmiento 888, General Sarmiento') 
INSERT INTO [dbo].[Companies]([Name],[Cuit],[Email],[Deleted],[Address]) 
VALUES ('Nutrix SRL','203012383829','Nutrix@gmail.com',0,'Granja A Brasil 87, General Pacheco') 
INSERT INTO [dbo].[Companies]([Name],[Cuit],[Email],[Deleted],[Address]) 
VALUES ('Granja SRL','20387736339','Granja@hotmail.com',0,'Granja B Brasil 8327, Pacheco') 
INSERT INTO [dbo].[Companies]([Name],[Cuit],[Email],[Deleted],[Address]) 
VALUES ('Nutrix SRL','2036667786789','Bertrix@live.com',0,'Granja C, General Pacheco') 
INSERT INTO [dbo].[Companies]([Name],[Cuit],[Email],[Deleted],[Address]) 
VALUES ('Nutrix SRL','2032478451369','Belatrix@outlook.com',0,'Granja D, General Pacheco') 
INSERT INTO [dbo].[Companies]([Name],[Cuit],[Email],[Deleted],[Address]) 
VALUES ('Nutrix SRL','2036879083459','Strange@dark.com',0,'Hirigoyen 2089, La loma') 

--CompanyTutor
INSERT INTO [dbo].[CompanyTutor]([Names],[Surnames],[Dni],[Cuil],[Email],[Deleted],[Sex],[Birthdate],[CompanyId])
VALUES('Gabriel Gonzalo','Corvalan','40475304','20404753046','Gabrielcn6@gmail.com',0,'Masculino','2018-08-06',1000) 
INSERT INTO [dbo].[CompanyTutor]([Names],[Surnames],[Dni],[Cuil],[Email],[Deleted],[Sex],[Birthdate],[CompanyId])
VALUES('Marcos Gonzalo','Spinetta','40465304','204047533446','MarcosSpi@gmail.com',0,'Masculino','2018-08-08',1000) 
INSERT INTO [dbo].[CompanyTutor]([Names],[Surnames],[Dni],[Cuil],[Email],[Deleted],[Sex],[Birthdate],[CompanyId])
VALUES('Nicolas Gonzalo','Menester','20475304','20404767646','Nicolas@gmail.com',0,'Masculino','2018-08-07',1000) 

--Pages
INSERT INTO [dbo].[Pages]([Name],[Description],[Icon],[Tittle],[Deleted])
VALUES('students','Pagina de Estudiantes',NULL,'Estudiantes',0) 
INSERT INTO [dbo].[Pages]([Name],[Description],[Icon],[Tittle],[Deleted])
VALUES('teachers','Pagina de Profesores',NULL,'Profesores',0) 
INSERT INTO [dbo].[Pages]([Name],[Description],[Icon],[Tittle],[Deleted])
VALUES('internships','Pagina de Pasantias',NULL,'Pasantias',0) 

--Rols
INSERT INTO [dbo].[Rols]([Name],[Deleted])VALUES('Administrador',0)
INSERT INTO [dbo].[Rols]([Name],[Deleted])VALUES('Observador',0)
INSERT INTO [dbo].[Rols]([Name],[Deleted])VALUES('Administrativo',0)

--Teachers
INSERT INTO [dbo].[Teachers]([Names],[Surnames],[Dni],[Cuil],[Email],[Address],[File],[Deleted],[Sex],[Birthdate])
VALUES('Ramon Ariel','Avila','203048524','20707453047','RamoAvi@live.com','Hipolito 3223, Palermo','208456',0,'Masculino','1970-08-07')

INSERT INTO [dbo].[Teachers]([Names],[Surnames],[Dni],[Cuil],[Email],[Address],[File],[Deleted],[Sex],[Birthdate])
VALUES('Maximiliano','Fernandez','303048524','20305453047','Maxisarfer@live.com','Tortugas 3223, Tortu','202356',0,'Masculino','1970-08-07')

INSERT INTO [dbo].[Teachers]([Names],[Surnames],[Dni],[Cuil],[Email],[Address],[File],[Deleted],[Sex],[Birthdate])
VALUES('Romina','Coria','209048524','20707459047','Rocoria@gmail.com','Hipolito 3223, Pacheco','203456',0,'Femenino','1970-08-07')

--Students
INSERT INTO [dbo].[Students]([Names],[Surnames],[Dni],[Cuil],[File],[CareerId],[TeacherGuideId],[Birthdate],[Address],[Email],[Deleted],[Sex])
VALUES('Martin','Delgadillo','40475304','20404753046','20800',1000,1000,'1993-08-08','Los troncos 6785','Martin@live.com',0,'Masculino')

INSERT INTO [dbo].[Students]([Names],[Surnames],[Dni],[Cuil],[File],[CareerId],[TeacherGuideId],[Birthdate],[Address],[Email],[Deleted],[Sex])
VALUES('Martin','Basualdo','40466304','20203453046','20720',1000,1000,'1997-08-08','Los troncos 6785','Diego@live.com',0,'Masculino')

INSERT INTO [dbo].[Students]([Names],[Surnames],[Dni],[Cuil],[File],[CareerId],[TeacherGuideId],[Birthdate],[Address],[Email],[Deleted],[Sex])
VALUES('Gabriel','Delgadillo','404385404','20804836046','90872',1000,1000,'1980-03-08','El talar 6785','Marcos@live.com',0,'Masculino')


--PagesRols
INSERT INTO [dbo].[PagesRols]([PageId],[RolId],[Write],[Read],[Update])
VALUES(1000,1000,1,1,1) 
INSERT INTO [dbo].[PagesRols]([PageId],[RolId],[Write],[Read],[Update])
VALUES(1001,1000,1,1,1) 
INSERT INTO [dbo].[PagesRols]([PageId],[RolId],[Write],[Read],[Update])
VALUES(1002,1000,1,1,1) 
INSERT INTO [dbo].[PagesRols]([PageId],[RolId],[Write],[Read],[Update])
VALUES(1000,1001,0,1,0) 
INSERT INTO [dbo].[PagesRols]([PageId],[RolId],[Write],[Read],[Update])
VALUES(1001,1001,0,1,0) 
INSERT INTO [dbo].[PagesRols]([PageId],[RolId],[Write],[Read],[Update])
VALUES(1002,1001,0,1,0) 
INSERT INTO [dbo].[PagesRols]([PageId],[RolId],[Write],[Read],[Update])
VALUES(1000,1002,1,1,0) 
INSERT INTO [dbo].[PagesRols]([PageId],[RolId],[Write],[Read],[Update])
VALUES(1001,1002,1,1,0) 
INSERT INTO [dbo].[PagesRols]([PageId],[RolId],[Write],[Read],[Update])
VALUES(1002,1002,1,1,0) 

--Users
INSERT INTO [dbo].[Users]([RolId],[Names],[Surnames],[Dni],[Cuil],[Email],[Address],[Sex],[UniversityPosition],[Password],[Birthdate],[Deleted])
VALUES(1000,'Gabriel','Corvalan','40475304','20404753046','Gabrielcn6@gmail.com','Brasil 2693, Benavidez','Masculino','Developer','admin','1997-08-06',0)

INSERT INTO [dbo].[Users]([RolId],[Names],[Surnames],[Dni],[Cuil],[Email],[Address],[Sex],[UniversityPosition],[Password],[Birthdate],[Deleted])
VALUES(1001,'Jose Luis','Garcia','17233434','12174753236','Joseluisgarcia@gmail.com','La loma 98923, Tigre','Masculino','Decano','decano','1950-08-06',0)


--Internships

INSERT INTO [dbo].[Interships]([StudentId],[CompanyId],[CompanyTutorId],[StartDate],[EndDate],[SalaryWorkAssignment],
			[WorkAgreement],[CompanySignatory],[DailyHours],[CreatedDate],[UserCreatedId],[LastModified],[UserLasModifiedId],
			[CancellationDate],[UserCancelattionId],[TaskDescription],[CancellationDescription],[RenovationDate],
			[UserRenovationId],[ConfirmationState],[Observations],[State],[Deleted])
     VALUES(1000,1001,1000,'2018-10-03','2020-10-03',10000,'Sistemas informaticos','Mariela Bracamonte',6,'2018-09-10',
	 1000,NULL,NULL,NULL,NULL,'Realizar tareas de mantenimiento a aplicaciones y desarrollar nuevas funcionalidades'
	 ,NULL,NULL,NULL,'Confirmada',NULL,'Nueva',0)











