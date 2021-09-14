USE [InstMgntDemoDB]
GO

/****** Object: Table [dbo].[StudentEnrolls] Script Date: 9/12/2021 9:08:19 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

DROP TABLE [dbo].[StudentEnrolls];


GO
CREATE TABLE [dbo].[StudentEnrolls] (
    [StudentEnrollId] AS (((format(getdate(),'yy')+'STU')+[dbo].[ufnGetBranchName]([BranchId]))+right(replicate('0',(4))+CONVERT([varchar],[Id]),(5))),
    [StudentInfoId]   INT            NOT NULL,
    [BranchId]        INT            NOT NULL,
    [Semester]        INT            NOT NULL,
    [Section]         INT            NOT NULL,
    [Id]              INT            IDENTITY (1, 1) NOT NULL
);


