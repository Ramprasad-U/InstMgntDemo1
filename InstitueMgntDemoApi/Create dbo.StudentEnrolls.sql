USE [InstMgntDemoDB]
GO

/****** Object: Table [dbo].[StudentEnrolls] Script Date: 9/12/2021 8:54:51 PM ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[StudentEnrolls] (
    [StudentEnrollId] AS (((format(getdate(),'yy')+'STU')+[dbo].[ufnGetBranchName]([BranchId]))+right(replicate('0',(4))+CONVERT([varchar],[Id]),(5))),
    [StudentInfoId]   INT            NOT NULL,
    [BranchId]        INT            NOT NULL,
    [Semester]        INT            NOT NULL,
    [Section]         INT            NOT NULL,
    [Id]              INT            IDENTITY (1, 1) NOT NULL
);


GO
CREATE NONCLUSTERED INDEX [IX_StudentEnrolls_BranchId]
    ON [dbo].[StudentEnrolls]([BranchId] ASC);


GO
CREATE NONCLUSTERED INDEX [IX_StudentEnrolls_StudentInfoId]
    ON [dbo].[StudentEnrolls]([StudentInfoId] ASC);


GO
ALTER TABLE [dbo].[StudentEnrolls]
    ADD CONSTRAINT [PK_StudentEnrolls] PRIMARY KEY CLUSTERED ([Id] ASC);


GO
ALTER TABLE [dbo].[StudentEnrolls]
    ADD CONSTRAINT [FK_StudentEnrolls_Branches_BranchId] FOREIGN KEY ([BranchId]) REFERENCES [dbo].[Branches] ([BranchId]) ON DELETE CASCADE;


GO
ALTER TABLE [dbo].[StudentEnrolls]
    ADD CONSTRAINT [FK_StudentEnrolls_StudentInfos_StudentInfoId] FOREIGN KEY ([StudentInfoId]) REFERENCES [dbo].[StudentInfos] ([StudentInfoId]) ON DELETE CASCADE;


