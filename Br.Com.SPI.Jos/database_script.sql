USE SPI_JOST_RI_ELETRONICO

GO

/*****************************************/
/********** MedicoesCab ******************/
/*****************************************/

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spGetMedicoesCab'))
BEGIN
	DROP PROCEDURE spGetMedicoesCab
END

GO

CREATE PROCEDURE spGetMedicoesCab
AS
BEGIN TRY
	SELECT * FROM MedicoesCab
END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spGetMedicoesCabByID'))
BEGIN
	DROP PROCEDURE spGetMedicoesCabByID
END

GO

CREATE PROCEDURE spGetMedicoesCabByID
(
@ID BIGINT
)
AS
BEGIN TRY
	SELECT * FROM MedicoesCab WHERE Id = @ID
END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spSaveUpdateMedicoesCab'))
BEGIN
	DROP PROCEDURE spSaveUpdateMedicoesCab
END

GO

CREATE PROCEDURE spSaveUpdateMedicoesCab
(
@Id BIGINT,
@IdPlanoInspecaoCab BIGINT,
@idOrdemProducao BIGINT,
@dataInicio DATETIME,
@datafim DATETIME,
@dataRI DATETIME
)
AS
BEGIN TRY
	IF EXISTS(SELECT * FROM MedicoesCab WHERE Id = @id)
	BEGIN
		UPDATE MedicoesCab SET
		IdPlanoInspecaoCab = @IdPlanoInspecaoCab,
		idOrdemProducao = @idOrdemProducao,
		dataInicio = @dataInicio,
		datafim = @datafim,
		dataRI = @dataRI
		WHERE Id = @id
	END
	ELSE
	BEGIN
		INSERT INTO MedicoesCab 
		(IdPlanoInspecaoCab, idOrdemProducao, dataInicio, datafim, dataRI) VALUES
		(@IdPlanoInspecaoCab, @idOrdemProducao, @dataInicio, @datafim, @dataRI)
	END

	SELECT @@ROWCOUNT AS Retorno
END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spGetMedicaoCabByPlanoInspecaoCab'))
BEGIN
	DROP PROCEDURE spGetMedicaoCabByPlanoInspecaoCab
END

GO

CREATE PROCEDURE spGetMedicaoCabByPlanoInspecaoCab
(
@IDPLANOCAB BIGINT
)
AS
BEGIN TRY
	SELECT * FROM MedicoesCab WHERE IdPlanoInspecaoCab = @IDPLANOCAB
END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO

/*****************************************/
/********** MedicoesCaract ***************/
/*****************************************/

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spGetMedicaoCaracByPlanoInspecaoCarac'))
BEGIN
	DROP PROCEDURE spGetMedicaoCaracByPlanoInspecaoCarac
END

GO

CREATE PROCEDURE spGetMedicaoCaracByPlanoInspecaoCarac
(
@IDPLANOCARAC BIGINT
)
AS
BEGIN TRY
	SELECT * FROM MedicoesCaract WHERE idPlanoInspecaoCaract = @IDPLANOCARAC
END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spGetMedicaoCaracByMedicaoCab'))
BEGIN
	DROP PROCEDURE spGetMedicaoCaracByMedicaoCab
END

GO

CREATE PROCEDURE spGetMedicaoCaracByMedicaoCab
(
@IDMEDICAOCAB BIGINT
)
AS
BEGIN TRY
	SELECT * FROM MedicoesCaract WHERE idMedicoesCab = @IDMEDICAOCAB
END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spAtualizaValorMedido'))
BEGIN
	DROP PROCEDURE spAtualizaValorMedido
END

GO

CREATE PROCEDURE spAtualizaValorMedido
(
@IDMedicaoCarac BIGINT,
@ValorMedido VARCHAR(50)
)
AS
BEGIN TRY
	UPDATE MedicoesCaract SET
	valorMedido = @ValorMedido
	WHERE Id = @IDMedicaoCarac

	SELECT @@ROWCOUNT AS Retorno
END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO

/*****************************************/
/********** Tipomedicao ******************/
/*****************************************/

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spGetTipoMedicaoByID'))
BEGIN
	DROP PROCEDURE spGetTipoMedicaoByID
END

GO

CREATE PROCEDURE spGetTipoMedicaoByID
(
@ID BIGINT
)
AS
BEGIN TRY
	SELECT * FROM TipoMedicoes WHERE Id = @ID
END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO

/*****************************************/
/*************** MotivosN1 ***************/
/*****************************************/

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spGetMotivosN1'))
BEGIN
	DROP PROCEDURE spGetMotivosN1
END

GO

CREATE PROCEDURE spGetMotivosN1
AS
BEGIN TRY
	SELECT * FROM MotivosN1
END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spGetMotivosN1ByID'))
BEGIN
	DROP PROCEDURE spGetMotivosN1ByID
END

GO

CREATE PROCEDURE spGetMotivosN1ByID
(
@Id BIGINT
)
AS
BEGIN TRY
	SELECT * FROM MotivosN1 WHERE id = @Id
END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spSaveUpdateMotivosN1'))
BEGIN
	DROP PROCEDURE spSaveUpdateMotivosN1
END

GO

CREATE PROCEDURE spSaveUpdateMotivosN1
(
@Id BIGINT,
@descMotivoN1 VARCHAR(50),
@dataRI DATETIME
)
AS
BEGIN TRY
	
	DECLARE @OutputID TABLE (ID BIGINT)

	IF EXISTS(SELECT * FROM MotivosN1 WHERE id = @Id)
	BEGIN
		UPDATE MotivosN1 SET
		descMotivoN1 = @descMotivoN1,
		dataRI = @dataRI
		WHERE id = @Id

		INSERT INTO @OutputID VALUES(@Id)
	END
	ELSE
	BEGIN 
		INSERT INTO MotivosN1 (descMotivoN1, dataRI) OUTPUT inserted.id INTO @OutputID VALUES (@descMotivoN1, @dataRI)
	END

	SELECT ID FROM @OutputID
END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spDeleteMotivoN1'))
BEGIN
	DROP PROCEDURE spDeleteMotivoN1
END

GO

CREATE PROCEDURE spDeleteMotivoN1
(
@Id BIGINT
)
AS
BEGIN TRY
	DELETE FROM MotivosN1 WHERE id = @Id
	SELECT @@ROWCOUNT AS Retorno
END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO

/*****************************************/
/*************** MotivosN2 ***************/
/*****************************************/

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spGetMotivosN2'))
BEGIN
	DROP PROCEDURE spGetMotivosN2
END

GO

CREATE PROCEDURE spGetMotivosN2
AS
BEGIN TRY
	SELECT * FROM MotivosN2
END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spGetMotivosN2ByID'))
BEGIN
	DROP PROCEDURE spGetMotivosN2ByID
END

GO

CREATE PROCEDURE spGetMotivosN2ByID
(
@Id BIGINT
)
AS
BEGIN TRY
	SELECT * FROM MotivosN2 WHERE id = @Id
END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spGetMotivosN2ByIDMotivoN1'))
BEGIN
	DROP PROCEDURE spGetMotivosN2ByIDMotivoN1
END

GO

CREATE PROCEDURE spGetMotivosN2ByIDMotivoN1
(
@idMotivoN1 BIGINT
)
AS
BEGIN TRY
	SELECT * FROM MotivosN2 WHERE idMotivoN1 = @idMotivoN1
END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spSaveUpdateMotivosN2'))
BEGIN
	DROP PROCEDURE spSaveUpdateMotivosN2
END

GO

CREATE PROCEDURE spSaveUpdateMotivosN2
(
@Id BIGINT,
@IdMotivoN1 BIGINT,
@descMotivoN2 VARCHAR(50),
@dataRI DATETIME
)
AS
BEGIN TRY

	DECLARE @OutputID TABLE (ID BIGINT)

	IF EXISTS(SELECT * FROM MotivosN2 WHERE id = @Id)
	BEGIN
		UPDATE MotivosN2 SET
		idMotivoN1 = @IdMotivoN1,
		descMotivoN2 = @descMotivoN2,
		dataRI = @dataRI
		WHERE id = @Id

		INSERT INTO @OutputID VALUES(@Id)
	END
	ELSE
	BEGIN 
		INSERT INTO MotivosN2 (idMotivoN1, descMotivoN2, dataRI) OUTPUT inserted.id INTO @OutputID VALUES (@IdMotivoN1, @descMotivoN2, @dataRI)
	END

	SELECT ID FROM @OutputID
END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spDeleteMotivoN2'))
BEGIN
	DROP PROCEDURE spDeleteMotivoN2
END

GO

CREATE PROCEDURE spDeleteMotivoN2
(
@Id BIGINT
)
AS
BEGIN TRY
	DELETE FROM MotivosN2 WHERE id = @Id
	SELECT @@ROWCOUNT AS Retorno
END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO

/*****************************************/
/*********** View ConsultaMedicao *********/
/*****************************************/

IF EXISTS(SELECT * FROM sys.views WHERE OBJECT_ID = object_id('medicoes'))
BEGIN
	DROP VIEW  medicoes
END

GO

CREATE VIEW medicoes
AS
SELECT TOP (100) PERCENT PICab.codItem, PICab.descItem, PICab.verPlano, PICab.codCC, PICab.descCC, MCab.dataInicio, MCab.datafim, PICaract.posicao, PICaract.tipo, PICaract.caracteristica, PICaract.class, MCaract.numMedicao, 
                  MCaract.valorMedido, TM.descTipo, MN1.descMotivoN1 + '/' + MN2.descMotivoN2 AS justificativa, MJ.RelatorioDeNaoConformidadeN AS relN, MJ.SolicitacaoDeDesvioDSV AS DSV, MCaract.dataMedicao, dbo.OrdemProducao.codOP, CAST(PICaract.limInf AS VARCHAR(10)) 
                  + '  - ' + CAST(PICaract.limSup AS VARCHAR(10)) AS limite
FROM     dbo.OrdemProducao RIGHT OUTER JOIN
                  dbo.MedicoesCab AS MCab INNER JOIN
                  dbo.PlanoInspecaoCaract AS PICaract ON MCab.IdPlanoInspecaoCab = PICaract.idPlanoInspecaoCab INNER JOIN
                  dbo.MedicoesCaract AS MCaract ON PICaract.Id = MCaract.idPlanoInspecaoCaract AND MCab.Id = MCaract.idMedicoesCab INNER JOIN
                  dbo.PlanoInspecaoCab AS PICab ON MCab.IdPlanoInspecaoCab = PICab.Id ON dbo.OrdemProducao.id = MCab.idOrdemProducao LEFT OUTER JOIN
                  dbo.MedicoesJustificativa AS MJ INNER JOIN
                  dbo.MotivosN1 AS MN1 INNER JOIN
                  dbo.MotivosN2 AS MN2 ON MN1.id = MN2.idMotivoN1 ON MJ.idMotivoN2 = MN2.id ON MCaract.Id = MJ.idMedicoesCaract LEFT OUTER JOIN
                  dbo.TipoMedicoes AS TM ON MCaract.idTipoMedicao = TM.Id
ORDER BY PICaract.posicao

GO

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spConsultaMedicaoBy'))
BEGIN
	DROP PROCEDURE spConsultaMedicaoBy
END

GO

CREATE PROCEDURE spConsultaMedicaoBy
(
@CT VARCHAR(50),
@DESCITEM VARCHAR(50),
@CODIGOOP VARCHAR(50),
@PPVERSAO VARCHAR(50),
@DATAINICIAL DATETIME,
@DATAFINAL DATETIME
)
AS
BEGIN TRY
	
	SELECT ROW_NUMBER() OVER (ORDER BY PICaract.posicao) AS Row,
	PICab.Id AS IDPlanoInspecaoCAB, PICaract.ID AS IDPlanoInspecaoCarac, MCab.Id AS IDMedicaoCab, MCaract.id AS IDMedicaoCarac, TM.Id AS IDTipoMedicao, MN1.id AS IDMotivoN1, MN2.id AS IDMotivoN2, OrdemProducao.id AS IDOrdemProducao,
	PICab.codItem, PICab.descItem, PICab.verPlano, PICab.codCC, PICab.CT, PICab.descCC, MCab.dataInicio, MCab.datafim, PICaract.posicao, PICaract.tipo, PICaract.caracteristica, PICaract.class, MCaract.numMedicao, 
	MCaract.valorMedido, TM.descTipo, MN1.descMotivoN1 + '/' + MN2.descMotivoN2 AS justificativa, MJ.RelatorioDeNaoConformidadeN AS relN, MJ.SolicitacaoDeDesvioDSV AS DSV, MCaract.dataMedicao, dbo.OrdemProducao.codOP, CAST(PICaract.limInf AS VARCHAR(10)) 
	+ '  - ' + CAST(PICaract.limSup AS VARCHAR(10)) AS limite, MCaract.numMatricula, PICaract.limInf, PICaract.limSup, PICaract.tipoCarac, PICab.planoPadraoVersao
	FROM     
	dbo.OrdemProducao RIGHT OUTER JOIN
	dbo.MedicoesCab AS MCab INNER JOIN
	dbo.PlanoInspecaoCaract AS PICaract ON MCab.IdPlanoInspecaoCab = PICaract.idPlanoInspecaoCab INNER JOIN
	dbo.MedicoesCaract AS MCaract ON PICaract.Id = MCaract.idPlanoInspecaoCaract AND MCab.Id = MCaract.idMedicoesCab INNER JOIN
	dbo.PlanoInspecaoCab AS PICab ON MCab.IdPlanoInspecaoCab = PICab.Id ON dbo.OrdemProducao.id = MCab.idOrdemProducao LEFT OUTER JOIN
	dbo.MedicoesJustificativa AS MJ INNER JOIN
	dbo.MotivosN1 AS MN1 INNER JOIN
	dbo.MotivosN2 AS MN2 ON MN1.id = MN2.idMotivoN1 ON MJ.idMotivoN2 = MN2.id ON MCaract.Id = MJ.idMedicoesCaract LEFT OUTER JOIN
	dbo.TipoMedicoes AS TM ON MCaract.idTipoMedicao = TM.Id
	WHERE 
	PICab.CT = ISNULL(@CT, PICab.CT) AND 
	PICab.descItem = ISNULL(@DESCITEM, PICab.descItem) AND 
	PICab.planoPadraoVersao = ISNULL(@PPVERSAO, PICab.planoPadraoVersao) AND
	dbo.OrdemProducao.codOP = ISNULL(@CODIGOOP, dbo.OrdemProducao.codOP) AND
	CONVERT(DATE, MCab.dataInicio) >= CONVERT(DATE, ISNULL(@DATAINICIAL, MCab.dataInicio)) AND
	CONVERT(DATE, MCab.datafim) <= CONVERT(DATE, ISNULL(@DATAFINAL, MCab.datafim))

END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spConsultaItemReprovadoBy'))
BEGIN
	DROP PROCEDURE spConsultaItemReprovadoBy
END

GO

CREATE PROCEDURE spConsultaItemReprovadoBy
(
@CT VARCHAR(50),
@DESCITEM VARCHAR(50),
@CODIGOOP VARCHAR(50),
@PPVERSAO VARCHAR(50),
@DATAINICIAL DATETIME,
@DATAFINAL DATETIME
)
AS
BEGIN TRY
	
	SELECT ROW_NUMBER() OVER (ORDER BY PICaract.posicao) AS Row,
	PICab.Id AS IDPlanoInspecaoCAB, PICaract.ID AS IDPlanoInspecaoCarac, MCab.Id AS IDMedicaoCab, MCaract.id AS IDMedicaoCarac, TM.Id AS IDTipoMedicao, MN1.id AS IDMotivoN1, MN2.id AS IDMotivoN2, OrdemProducao.id AS IDOrdemProducao,
	PICab.codItem, PICab.descItem, PICab.verPlano, PICab.codCC, PICab.CT, PICab.descCC, MCab.dataInicio, MCab.datafim, PICaract.posicao, PICaract.tipo, PICaract.caracteristica, PICaract.class, MCaract.numMedicao, 
	MCaract.valorMedido, TM.descTipo, MN1.descMotivoN1 + '/' + MN2.descMotivoN2 AS justificativa, MJ.RelatorioDeNaoConformidadeN AS relN, MJ.SolicitacaoDeDesvioDSV AS DSV, MCaract.dataMedicao, dbo.OrdemProducao.codOP, CAST(PICaract.limInf AS VARCHAR(10)) 
	+ '  - ' + CAST(PICaract.limSup AS VARCHAR(10)) AS limite, MCaract.numMatricula, PICaract.limInf, PICaract.limSup, PICaract.tipoCarac, PICab.planoPadraoVersao
	FROM     
	dbo.OrdemProducao RIGHT OUTER JOIN
	dbo.MedicoesCab AS MCab INNER JOIN
	dbo.PlanoInspecaoCaract AS PICaract ON MCab.IdPlanoInspecaoCab = PICaract.idPlanoInspecaoCab INNER JOIN
	dbo.MedicoesCaract AS MCaract ON PICaract.Id = MCaract.idPlanoInspecaoCaract AND MCab.Id = MCaract.idMedicoesCab INNER JOIN
	dbo.PlanoInspecaoCab AS PICab ON MCab.IdPlanoInspecaoCab = PICab.Id ON dbo.OrdemProducao.id = MCab.idOrdemProducao INNER JOIN
	dbo.MedicoesJustificativa AS MJ INNER JOIN
	dbo.MotivosN1 AS MN1 INNER JOIN
	dbo.MotivosN2 AS MN2 ON MN1.id = MN2.idMotivoN1 ON MJ.idMotivoN2 = MN2.id ON MCaract.Id = MJ.idMedicoesCaract LEFT OUTER JOIN
	dbo.TipoMedicoes AS TM ON MCaract.idTipoMedicao = TM.Id
	WHERE 
	PICab.CT = ISNULL(@CT, PICab.CT) AND 
	PICab.descItem = ISNULL(@DESCITEM, PICab.descItem) AND 
	PICab.planoPadraoVersao = ISNULL(@PPVERSAO, PICab.planoPadraoVersao) AND
	dbo.OrdemProducao.codOP = ISNULL(@CODIGOOP, dbo.OrdemProducao.codOP) AND
	CONVERT(DATE, MCab.dataInicio) >= CONVERT(DATE, ISNULL(@DATAINICIAL, MCab.dataInicio)) AND
	CONVERT(DATE, MCab.datafim) <= CONVERT(DATE, ISNULL(@DATAFINAL, MCab.datafim))

END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO


IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spConsultaMedicao'))
BEGIN
	DROP PROCEDURE spConsultaMedicao
END

GO

CREATE PROCEDURE spConsultaMedicao
AS
BEGIN TRY
	SELECT * FROM medicoes
END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO

/*****************************************/
/********** PlanoInspecaoCab *************/
/*****************************************/

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spGetPlanoInspecaoCab'))
BEGIN
	DROP PROCEDURE spGetPlanoInspecaoCab
END

GO

CREATE PROCEDURE spGetPlanoInspecaoCab
AS
BEGIN TRY
	SELECT * FROM PlanoInspecaoCab
END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spGetPlanoInspecaoCabCodigoCC'))
BEGIN
	DROP PROCEDURE spGetPlanoInspecaoCabCodigoCC
END

GO

CREATE PROCEDURE spGetPlanoInspecaoCabCodigoCC
AS
BEGIN TRY
	SELECT ct FROM PlanoInspecaoCab GROUP BY ct
END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spGetPlanoInspecaoCabCodigoItem'))
BEGIN
	DROP PROCEDURE spGetPlanoInspecaoCabCodigoItem
END

GO

CREATE PROCEDURE spGetPlanoInspecaoCabCodigoItem
AS
BEGIN TRY
	SELECT codItem FROM PlanoInspecaoCab GROUP BY codItem
END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spGetPlanoInspecaoCabVersaoPlanoPadrao'))
BEGIN
	DROP PROCEDURE spGetPlanoInspecaoCabVersaoPlanoPadrao
END

GO

CREATE PROCEDURE spGetPlanoInspecaoCabVersaoPlanoPadrao
AS
BEGIN TRY
	SELECT planoPadraoVersao FROM PlanoInspecaoCab GROUP BY planoPadraoVersao
END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spGetPlanoInspecaoCabBy'))
BEGIN
	DROP PROCEDURE spGetPlanoInspecaoCabBy
END

GO

CREATE PROCEDURE spGetPlanoInspecaoCabBy
(
@CT VARCHAR(50),
@CODIGOITEM VARCHAR(50),
@CODIGOOP VARCHAR(50),
@PPVERSAO VARCHAR(50),
@DATAINICIAL DATETIME,
@DATAFINAL DATETIME
)
AS
BEGIN TRY
	SELECT PICab.ID, PICab.codItem, PICab.descItem, PICab.verPlano, PICab.codCC, PICab.planoPadrao, MCab.dataRI, PICab.CT, PICab.planoPadraoVersao, OrdemProd.codOP
	FROM PlanoInspecaoCab PICab 
	INNER JOIN MedicoesCab MCab ON PICab.Id = MCab.IdPlanoInspecaoCab
	LEFT JOIN OrdemProducao OrdemProd ON MCab.idOrdemProducao = OrdemProd.id
	WHERE 
	PICab.CT = ISNULL(@CT, PICab.CT) AND 
	PICab.codItem = ISNULL(@CODIGOITEM, PICab.codItem) AND 
	OrdemProd.codOP = ISNULL(@CODIGOOP, OrdemProd.codOP) AND
	PICab.planoPadraoVersao = ISNULL(@PPVERSAO, PICab.planoPadraoVersao) AND
	CONVERT(DATE, MCab.dataInicio) >= CONVERT(DATE, ISNULL(@DATAINICIAL, MCab.dataInicio)) AND
	CONVERT(DATE, MCab.datafim) <= CONVERT(DATE, ISNULL(@DATAFINAL, MCab.datafim))
	GROUP BY PICab.ID, PICab.codItem, PICab.descItem, PICab.verPlano, PICab.codCC, PICab.planoPadrao, MCab.dataRI, PICab.CT, PICab.planoPadraoVersao, OrdemProd.codOP

END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO


/*****************************************/
/********** PlanoInspecaoCaract **********/
/*****************************************/

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spGetPlanoInspecaocaracByPlanoInspecaoCab'))
BEGIN
	DROP PROCEDURE spGetPlanoInspecaocaracByPlanoInspecaoCab
END

GO

CREATE PROCEDURE spGetPlanoInspecaocaracByPlanoInspecaoCab
(
@IDPLANOCAB BIGINT
)
AS
BEGIN TRY
	SELECT * FROM PlanoInspecaoCaract WHERE idPlanoInspecaoCab = @IDPLANOCAB
END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO


/*****************************************/
/********** OrdemProducao *************/
/*****************************************/

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spGetOrdemProducao'))
BEGIN
	DROP PROCEDURE spGetOrdemProducao
END

GO

CREATE PROCEDURE spGetOrdemProducao
AS
BEGIN TRY
	SELECT * FROM OrdemProducao
END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO

IF EXISTS(SELECT * FROM sys.procedures WHERE OBJECT_ID = object_id('spGetOrdemProducaoByID'))
BEGIN
	DROP PROCEDURE spGetOrdemProducaoByID
END

GO

CREATE PROCEDURE spGetOrdemProducaoByID
(
@ID BIGINT
)
AS
BEGIN TRY
	SELECT * FROM OrdemProducao WHERE id = @ID
END TRY
BEGIN CATCH
	SELECT 0 AS Retorno, ERROR_MESSAGE() AS Mensagem
END CATCH

GO

