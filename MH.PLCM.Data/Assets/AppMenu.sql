USE [Northwind]
GO

/****** Object:  Table [dbo].[AppMenus]    Script Date: 3/27/2020 2:46:02 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[AppMenus](
	[Id] [int] IDENTITY(7,1) NOT NULL,
	[MenuCodeName] [varchar](50) NOT NULL,
	[DisplayName] [nvarchar](50) NOT NULL,
	[NavigationUrl] [nvarchar](50) NOT NULL,
	[Icon] [nvarchar](50) NOT NULL,
	[PermissionDependency] [nvarchar](100) NOT NULL,
	[Sequence] [int] NOT NULL,
	[IsEnabled] [bit] NOT NULL,
	[IsVisible] [bit] NOT NULL,
	[ParentId] [int] NOT NULL,
 CONSTRAINT [PK_AppMenus] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO

ALTER TABLE [dbo].[AppMenus] ADD  CONSTRAINT [DF_AppMenus_MenuCodeName]  DEFAULT ('') FOR [MenuCodeName]
GO

ALTER TABLE [dbo].[AppMenus] ADD  CONSTRAINT [DF_AppMenus_DisplayName]  DEFAULT ('') FOR [DisplayName]
GO

ALTER TABLE [dbo].[AppMenus] ADD  CONSTRAINT [DF_AppMenus_NavigationUrl]  DEFAULT ('') FOR [NavigationUrl]
GO

ALTER TABLE [dbo].[AppMenus] ADD  CONSTRAINT [DF_AppMenus_Icon]  DEFAULT ('') FOR [Icon]
GO

ALTER TABLE [dbo].[AppMenus] ADD  CONSTRAINT [DF_AppMenus_PermissionDependency]  DEFAULT ('') FOR [PermissionDependency]
GO

ALTER TABLE [dbo].[AppMenus] ADD  CONSTRAINT [DF_AppMenus_Sequence]  DEFAULT ((0)) FOR [Sequence]
GO

ALTER TABLE [dbo].[AppMenus] ADD  CONSTRAINT [DF_AppMenus_IsEnabled]  DEFAULT ((1)) FOR [IsEnabled]
GO

ALTER TABLE [dbo].[AppMenus] ADD  CONSTRAINT [DF_AppMenus_IsVisible]  DEFAULT ((1)) FOR [IsVisible]
GO

ALTER TABLE [dbo].[AppMenus] ADD  CONSTRAINT [DF_AppMenus_ParentId]  DEFAULT ((0)) FOR [ParentId]
GO


