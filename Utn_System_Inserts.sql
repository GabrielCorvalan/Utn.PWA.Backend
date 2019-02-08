USE [Utn_Sys]
GO

INSERT INTO [dbo].[Careers]([Name], [Deleted]) VALUES ('Tecnico Superior en Sistemas', 0) GO
INSERT INTO [dbo].[Careers]([Name], [Deleted]) VALUES ('Tecnico Superior en Arquitectura', 0) GO
INSERT INTO [dbo].[Careers]([Name], [Deleted]) VALUES ('Tecnico Superior en Infraestructura',0) GO
INSERT INTO [dbo].[Careers]([Name], [Deleted]) VALUES ('Ingenieria en Informatica', 0) GO

GO

INSERT INTO [dbo].[Companies]([Name],[Cuit],[Email],[Deleted],[Address]) VALUES ('Snoop Consulting','20304583829','Snoop@gmail.com',0,'Sarmiento 888, General Sarmiento') GO
INSERT INTO [dbo].[Companies]([Name],[Cuit],[Email],[Deleted],[Address]) VALUES ('Nutrix SRL','20304583829','Nutrix@gmail.com',0,'Granja A Brasil 87, General Pacheco') GO
INSERT INTO [dbo].[Companies]([Name],[Cuit],[Email],[Deleted],[Address]) VALUES ('Granja SRL','20387766339','Granja@hotmail.com',0,'Granja B Brasil 8327, Pacheco') GO
INSERT INTO [dbo].[Companies]([Name],[Cuit],[Email],[Deleted],[Address]) VALUES ('Nutrix SRL','20366676789','Bertrix@live.com',0,'Granja C, General Pacheco') GO
INSERT INTO [dbo].[Companies]([Name],[Cuit],[Email],[Deleted],[Address]) VALUES ('Nutrix SRL','20324784569','Belatrix@outlook.com',0,'Granja D, General Pacheco') GO
INSERT INTO [dbo].[Companies]([Name],[Cuit],[Email],[Deleted],[Address]) VALUES ('Nutrix SRL','20368790839','Strange@dark.com',0,'Hirigoyen 2089, La loma') GO

USE [Utn_Sys]
GO

INSERT INTO [dbo].[CompanyMentor]([Names],[Surnames],[Dni],[Cuil],[Email],[Deleted],[Sex],[Birthdate],[CompanyId])
VALUES('Gabriel Gonzalo','Corvalan','40475304','20404753046','Gabrielcn6@gmail.com',0,'Masculino','2018-08-06',1000) GO
INSERT INTO [dbo].[CompanyMentor]([Names],[Surnames],[Dni],[Cuil],[Email],[Deleted],[Sex],[Birthdate],[CompanyId])
VALUES('Marcos Gonzalo','Spinetta','40465304','204047533446','MarcosSpi@gmail.com',0,'Masculino','2018-08-08',1000) GO
INSERT INTO [dbo].[CompanyMentor]([Names],[Surnames],[Dni],[Cuil],[Email],[Deleted],[Sex],[Birthdate],[CompanyId])
VALUES('Nicolas Gonzalo','Menester','20475304','20404767646','Nicolas@gmail.com',0,'Masculino','2018-08-07',1000) GO

USE [Utn_Sys]
GO

INSERT INTO [dbo].[Pages]([Name],[Description],[Icon]) VALUES('students','Pagina de estudiantes',NULL)
INSERT INTO [dbo].[Pages]([Name],[Description],[Icon]) VALUES('teachers','Pagina de profesores',NULL)
INSERT INTO [dbo].[Pages]([Name],[Description],[Icon]) VALUES('internships','Pagina de pasantias',NULL)
GO





