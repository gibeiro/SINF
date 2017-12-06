using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Interop.ErpBS900;
using Interop.StdPlatBS900;
using Interop.StdBE900;
using Interop.GcpBE900;
using ADODB;

namespace FirstREST.Lib_Primavera
{
    public class PriIntegration
    {
        #region Overview

        public static List<Model.Custom.TopArtigos> TopArtigosDeCliente(string id, int n)
        {
            StdBELista objList;

            List<Model.Custom.TopArtigos> listArtigos = new List<Model.Custom.TopArtigos>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                objList = PriEngine.Engine.Consulta(
                    "SELECT TOP 5 LinhasDoc.Artigo, LinhasDoc.Descricao, SUM(LinhasDoc.PrecUnit * LinhasDoc.Quantidade) AS Price FROM LinhasDoc JOIN CabecDoc ON LinhasDoc.IdCabecDoc = CabecDoc.Id WHERE CabecDoc.Entidade = \'" + id + "\' GROUP BY Artigo, Descricao ORDER BY Price DESC"
                    );

                while (!objList.NoFim())
                {
                    listArtigos.Add(new Model.Custom.TopArtigos
                    {
                        CodArtigo = objList.Valor("Artigo"),
                        DescArtigo = objList.Valor("Descricao"),
                        Faturacao = objList.Valor("Price")
                    });
                    objList.Seguinte();

                }

                return listArtigos;
            }
            else
                return null;
        }

        //Clientes que geram mais faturacao
        public static List<Model.Custom.TopClientes> TopClientes(int n,int y)
        {
            StdBELista objList;

            List<Model.Custom.TopClientes> listClientes = new List<Model.Custom.TopClientes>();

            if (
                PriEngine.InitializeCompany(
                    FirstREST.Properties.Settings.Default.Company.Trim(),
                    FirstREST.Properties.Settings.Default.User.Trim(),
                    FirstREST.Properties.Settings.Default.Password.Trim()
                ) == true
               )
            {

                objList = PriEngine.Engine.Consulta(
                    "SELECT TOP "+ n +" CabecDoc.Entidade, SUM(CabecDoc.TotalMerc) AS Faturacao FROM CabecDoc WHERE YEAR(CabecDoc.Data) = " + y +"  GROUP BY CabecDoc.Entidade ORDER BY Faturacao DESC"
                    );

                while (!objList.NoFim() || n-- == 0)
                {
                    listClientes.Add(new Model.Custom.TopClientes
                    {
                        CodCliente = objList.Valor("Entidade"),
                        Faturacao = objList.Valor("Faturacao")
                    });
                    objList.Seguinte();

                }

                return listClientes;
            }
            else
                return null;

        }

        //Artigos que geram mais lucro
        public static List<Model.Custom.TopArtigos> TopArtigos(int n,int y)
        {
            StdBELista objList;

            List<Model.Custom.TopArtigos> listArtigos = new List<Model.Custom.TopArtigos>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                objList = PriEngine.Engine.Consulta(
                    "SELECT TOP " + n + " LinhasDoc.Artigo, LinhasDoc.Descricao, SUM(LinhasDoc.PrecUnit * LinhasDoc.Quantidade) AS Price FROM LinhasDoc WHERE YEAR(LinhasDoc.Data) = " + y + " GROUP BY Artigo,Descricao ORDER BY Price DESC"
                    );

                while (!objList.NoFim())
                {
                    listArtigos.Add(new Model.Custom.TopArtigos
                    {
                        CodArtigo = objList.Valor("Artigo"),
                        DescArtigo = objList.Valor("Descricao"),
                        Faturacao = objList.Valor("Price")
                    });
                    objList.Seguinte();

                }

                return listArtigos;
            }
            else
                return null;
        }

        private static Model.Custom.Growth GrowthMonth(int year, int month)
        {
            StdBELista objList;

            Model.Custom.Growth Growths = new Model.Custom.Growth();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                objList = PriEngine.Engine.Consulta(
                    "SELECT ISNULL(SUM(T.PrecUnit * T.Quantidade),0) AS TEarn, ISNULL(SUM(T.PCM * T.Quantidade),0) AS TCost FROM (SELECT PrecUnit,Quantidade,PCM FROM LinhasDoc WHERE YEAR(LinhasDoc.Data) = " + year + " AND MONTH(LinhasDoc.Data) = " + month + ") T");

                
                    Console.WriteLine(objList.Valor("TEarn"));
                    Growths = new Model.Custom.Growth
                    {
                        Earn = objList.Valor("TEarn"),
                        Cost = objList.Valor("TCost"),
                        Profit = objList.Valor("TEarn") - objList.Valor("TCost")
                    };
                    objList.Seguinte();

                

                return Growths;
            }
            else
                return null;
        }

        

        public static List<Model.Custom.Growth> GrowthYear(int year)
        {
            List<Model.Custom.Growth> growths = new List<Model.Custom.Growth>();
            for (int i = 1; i <= 12; i++)
            {
                growths.Add(GrowthMonth(year, i));
            }
            return growths;
        }

        #endregion Overview

        #region ViewCliente;
        //COMPRAS DE UM CERTO CLIENTE
        public static List<Model.CabecDoc> getClientPurchases(string codcliente)
        {
            StdBELista objList;

            List<Model.CabecDoc> vendas = new List<Model.CabecDoc>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                objList = PriEngine.Engine.Consulta(
                   "SELECT CabecDoc.id,CabecDoc.Data,CabecDoc.TotalMerc, CabecDoc.TotalIva FROM CabecDoc WHERE CabecDoc.Entidade = '" + codcliente + "' ORDER BY CabecDoc.Data DESC"
                );
                while (!objList.NoFim())
                {
                    vendas.Add(new Model.CabecDoc
                    {
                        Entidade = codcliente,
                        id = objList.Valor("id"),
                        Data = objList.Valor("Data"),
                        TotalMerc = objList.Valor("TotalMerc"),
                        TotalIva = objList.Valor("TotalIva")
                    });
                    objList.Seguinte();

                }
            }
            return vendas;
        }

        #endregion ViewCliente;

        #region ViewProducts

        public static List<Model.Artigo> ListaArtigos()
        {

            StdBELista objList;

            Model.Artigo art = new Model.Artigo();
            List<Model.Artigo> listArts = new List<Model.Artigo>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                objList = PriEngine.Engine.Consulta(
                    "SELECT Artigo.Artigo, Artigo.Descricao FROM Artigo"
                );

                while (!objList.NoFim())
                {
                    art = new Model.Artigo();
                    art.CodArtigo = objList.Valor("artigo");
                    art.DescArtigo = objList.Valor("descricao");
                    listArts.Add(art);
                    objList.Seguinte();
                }

                return listArts;

            }
            else
            {
                return null;

            }
        }

        public static Lib_Primavera.Model.Artigo GetArtigo(string codArtigo)
        {

            StdBELista objList;
            List<Model.Artigo> listArtigos = new List<Model.Artigo>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                if (PriEngine.Engine.Comercial.Artigos.Existe(codArtigo) == false)
                {
                    return null;
                }
                else
                {

                    objList = PriEngine.Engine.Consulta("SELECT Artigo.Artigo,Artigo.Descricao,Artigo.STKActual,Artigo.STKReposicao,Artigo.PCMedio,ArtigoMoeda.PVP1 FROM Artigo,ArtigoMoeda WHERE Artigo.Artigo = '" + codArtigo + "' AND Artigo.Artigo = ArtigoMoeda.Artigo");

                    while (!objList.NoFim())
                    {
                        listArtigos.Add(new Model.Artigo
                        {
                            CodArtigo = objList.Valor("Artigo"),
                            DescArtigo = objList.Valor("Descricao"),
                            STKAtual = objList.Valor("STKActual"),
                            STKReposicao = objList.Valor("STKReposicao"),
                            PCM = objList.Valor("PCMedio"),
                            PVP = objList.Valor("PVP1")
                        });
                        objList.Seguinte();

                    }

                    return listArtigos[0];
                }

            }
            else
            {
                return null;
            }
        }

        private static Model.Custom.SalesVol SalesVolMonth(string cod, int year, int month)
        {
            StdBELista objList;

            Model.Custom.SalesVol SalesVol = new Model.Custom.SalesVol();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                objList = PriEngine.Engine.Consulta(
                    "SELECT ISNULL(SUM(T.Quantidade),0) as NSold ,ISNULL(SUM(T.PrecUnit * T.Quantidade),0) AS TEarn, ISNULL(SUM(T.PCM * T.Quantidade),0) AS TCost FROM (SELECT PrecUnit,Quantidade,PCM FROM LinhasDoc WHERE LinhasDoc.Artigo = '" + cod + "' AND YEAR(LinhasDoc.Data) = " + year + " AND MONTH(LinhasDoc.Data) = " + month + ") T");

                SalesVol = new Model.Custom.SalesVol
                {
                    Sales = objList.Valor("NSold"),
                    Profit = objList.Valor("TEarn") - objList.Valor("TCost")
                };
                objList.Seguinte();



                return SalesVol;
            }
            else
                return null;
        }



        public static List<Model.Custom.SalesVol> SalesVolYear(string cod,int year)
        {
            List<Model.Custom.SalesVol> salesvol = new List<Model.Custom.SalesVol>();
            for (int i = 1; i <= 12; i++)
            {
                salesvol.Add(SalesVolMonth(cod,year, i));
            }
            return salesvol;
        }

        #endregion

        # region Cliente

        public static List<Model.Cliente> ListaClientes()
        {
            
            
            StdBELista objList;

            List<Model.Cliente> listClientes = new List<Model.Cliente>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                //objList = PriEngine.Engine.Comercial.Clientes.LstClientes();

                objList = PriEngine.Engine.Consulta("SELECT Cliente, Nome, Moeda, NumContrib as NumContribuinte, Fac_Mor AS campo_exemplo, CDU_Email as Email FROM  CLIENTES");

                
                while (!objList.NoFim())
                {
                    listClientes.Add(new Model.Cliente
                    {
                        CodCliente = objList.Valor("Cliente"),
                        NomeCliente = objList.Valor("Nome"),
                        Moeda = objList.Valor("Moeda"),
                        NumContribuinte = objList.Valor("NumContribuinte"),
                        Morada = objList.Valor("campo_exemplo"),
                        Email = objList.Valor("Email")
                    });
                    objList.Seguinte();

                }

                return listClientes;
            }
            else
                return null;
        }

        public static Lib_Primavera.Model.Cliente GetCliente(string codCliente)
        {
            

            GcpBECliente objCli = new GcpBECliente();


            Model.Cliente myCli = new Model.Cliente();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {

                if (PriEngine.Engine.Comercial.Clientes.Existe(codCliente) == true)
                {
                    
                    objCli = PriEngine.Engine.Comercial.Clientes.Edita(codCliente);
                    myCli.CodCliente = objCli.get_Cliente();
                    myCli.NomeCliente = objCli.get_Nome();
                    myCli.Moeda = objCli.get_Moeda();
                    myCli.NumContribuinte = objCli.get_NumContribuinte();
                    myCli.Morada = objCli.get_Morada();
                    myCli.Email = PriEngine.Engine.Comercial.Clientes.DaValorAtributo(codCliente, "CDU_Email");

                    
                    return myCli;
                }
                else
                {
                    return null;
                }
            }
            else
                return null;
        }

        public static Lib_Primavera.Model.RespostaErro UpdCliente(Lib_Primavera.Model.Cliente cliente)
        {
            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
           

            GcpBECliente objCli = new GcpBECliente();

            try
            {

                if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
                {

                    if (PriEngine.Engine.Comercial.Clientes.Existe(cliente.CodCliente) == false)
                    {
                        erro.Erro = 1;
                        erro.Descricao = "O cliente não existe";
                        return erro;
                    }
                    else
                    {

                        objCli = PriEngine.Engine.Comercial.Clientes.Edita(cliente.CodCliente);
                        objCli.set_EmModoEdicao(true);

                        objCli.set_Nome(cliente.NomeCliente);
                        objCli.set_NumContribuinte(cliente.NumContribuinte);
                        objCli.set_Moeda(cliente.Moeda);
                        objCli.set_Morada(cliente.Morada);
                        
                        PriEngine.Engine.Comercial.Clientes.Actualiza(objCli);

                        erro.Erro = 0;
                        erro.Descricao = "Sucesso";
                        return erro;
                    }
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir a empresa";
                    return erro;

                }

            }

            catch (Exception ex)
            {
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }

        }


        public static Lib_Primavera.Model.RespostaErro DelCliente(string codCliente)
        {

            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            GcpBECliente objCli = new GcpBECliente();


            try
            {

                if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
                {
                    if (PriEngine.Engine.Comercial.Clientes.Existe(codCliente) == false)
                    {
                        erro.Erro = 1;
                        erro.Descricao = "O cliente não existe";
                        return erro;
                    }
                    else
                    {

                        PriEngine.Engine.Comercial.Clientes.Remove(codCliente);
                        erro.Erro = 0;
                        erro.Descricao = "Sucesso";
                        return erro;
                    }
                }

                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir a empresa";
                    return erro;
                }
            }

            catch (Exception ex)
            {
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }

        }



        public static Lib_Primavera.Model.RespostaErro InsereClienteObj(Model.Cliente cli)
        {

            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            

            GcpBECliente myCli = new GcpBECliente();

            try
            {
                if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
                {

                    myCli.set_Cliente(cli.CodCliente);
                    myCli.set_Nome(cli.NomeCliente);
                    myCli.set_NumContribuinte(cli.NumContribuinte);
                    myCli.set_Moeda(cli.Moeda);
                    myCli.set_Morada(cli.Morada);

                    PriEngine.Engine.Comercial.Clientes.Actualiza(myCli);

                    erro.Erro = 0;
                    erro.Descricao = "Sucesso";
                    return erro;
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir empresa";
                    return erro;
                }
            }

            catch (Exception ex)
            {
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }


        }        

        #endregion Cliente;   // -----------------------------  END   CLIENTE    -----------------------
 
        #region DocCompra
        

        public static List<Model.DocCompra> VGR_List()
        {
                
            StdBELista objListCab;
            StdBELista objListLin;
            Model.DocCompra dc = new Model.DocCompra();
            List<Model.DocCompra> listdc = new List<Model.DocCompra>();
            Model.LinhaDocCompra lindc = new Model.LinhaDocCompra();
            List<Model.LinhaDocCompra> listlindc = new List<Model.LinhaDocCompra>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT id, NumDocExterno, Entidade, DataDoc, NumDoc, TotalMerc, Serie From CabecCompras where TipoDoc='VGR'");
                while (!objListCab.NoFim())
                {
                    dc = new Model.DocCompra();
                    dc.id = objListCab.Valor("id");
                    dc.NumDocExterno = objListCab.Valor("NumDocExterno");
                    dc.Entidade = objListCab.Valor("Entidade");
                    dc.NumDoc = objListCab.Valor("NumDoc");
                    dc.Data = objListCab.Valor("DataDoc");
                    dc.TotalMerc = objListCab.Valor("TotalMerc");
                    dc.Serie = objListCab.Valor("Serie");
                    objListLin = PriEngine.Engine.Consulta("SELECT idCabecCompras, Artigo, Descricao, Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido, Armazem, Lote from LinhasCompras where IdCabecCompras='" + dc.id + "' order By NumLinha");
                    listlindc = new List<Model.LinhaDocCompra>();

                    while (!objListLin.NoFim())
                    {
                        lindc = new Model.LinhaDocCompra();
                        lindc.IdCabecDoc = objListLin.Valor("idCabecCompras");
                        lindc.CodArtigo = objListLin.Valor("Artigo");
                        lindc.DescArtigo = objListLin.Valor("Descricao");
                        lindc.Quantidade = objListLin.Valor("Quantidade");
                        lindc.Unidade = objListLin.Valor("Unidade");
                        lindc.Desconto = objListLin.Valor("Desconto1");
                        lindc.PrecoUnitario = objListLin.Valor("PrecUnit");
                        lindc.TotalILiquido = objListLin.Valor("TotalILiquido");
                        lindc.TotalLiquido = objListLin.Valor("PrecoLiquido");
                        lindc.Armazem = objListLin.Valor("Armazem");
                        lindc.Lote = objListLin.Valor("Lote");

                        listlindc.Add(lindc);
                        objListLin.Seguinte();
                    }

                    dc.LinhasDoc = listlindc;
                    
                    listdc.Add(dc);
                    objListCab.Seguinte();
                }
            }
            return listdc;
        }

                
        public static Model.RespostaErro VGR_New(Model.DocCompra dc)
        {
            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            

            GcpBEDocumentoCompra myGR = new GcpBEDocumentoCompra();
            GcpBELinhaDocumentoCompra myLin = new GcpBELinhaDocumentoCompra();
            GcpBELinhasDocumentoCompra myLinhas = new GcpBELinhasDocumentoCompra();

            PreencheRelacaoCompras rl = new PreencheRelacaoCompras();
            List<Model.LinhaDocCompra> lstlindv = new List<Model.LinhaDocCompra>();

            try
            {
                if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
                {
                    // Atribui valores ao cabecalho do doc
                    //myEnc.set_DataDoc(dv.Data);
                    myGR.set_Entidade(dc.Entidade);
                    myGR.set_NumDocExterno(dc.NumDocExterno);
                    myGR.set_Serie(dc.Serie);
                    myGR.set_Tipodoc("VGR");
                    myGR.set_TipoEntidade("F");
                    // Linhas do documento para a lista de linhas
                    lstlindv = dc.LinhasDoc;
                    //PriEngine.Engine.Comercial.Compras.PreencheDadosRelacionados(myGR,rl);
                    PriEngine.Engine.Comercial.Compras.PreencheDadosRelacionados(myGR);
                    foreach (Model.LinhaDocCompra lin in lstlindv)
                    {
                        PriEngine.Engine.Comercial.Compras.AdicionaLinha(myGR, lin.CodArtigo, lin.Quantidade, lin.Armazem, "", lin.PrecoUnitario, lin.Desconto);
                    }


                    PriEngine.Engine.IniciaTransaccao();
                    PriEngine.Engine.Comercial.Compras.Actualiza(myGR, "Teste");
                    PriEngine.Engine.TerminaTransaccao();
                    erro.Erro = 0;
                    erro.Descricao = "Sucesso";
                    return erro;
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir empresa";
                    return erro;

                }

            }
            catch (Exception ex)
            {
                PriEngine.Engine.DesfazTransaccao();
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }
        }


        #endregion DocCompra

        #region DocsVenda

        public static Model.RespostaErro Encomendas_New(Model.DocVenda dv)
        {
            Lib_Primavera.Model.RespostaErro erro = new Model.RespostaErro();
            GcpBEDocumentoVenda myEnc = new GcpBEDocumentoVenda();
             
            GcpBELinhaDocumentoVenda myLin = new GcpBELinhaDocumentoVenda();

            GcpBELinhasDocumentoVenda myLinhas = new GcpBELinhasDocumentoVenda();
             
            PreencheRelacaoVendas rl = new PreencheRelacaoVendas();
            List<Model.LinhaDocVenda> lstlindv = new List<Model.LinhaDocVenda>();
            
            try
            {
                if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
                {
                    // Atribui valores ao cabecalho do doc
                    //myEnc.set_DataDoc(dv.Data);
                    myEnc.set_Entidade(dv.Entidade);
                    myEnc.set_Serie(dv.Serie);
                    myEnc.set_Tipodoc("ECL");
                    myEnc.set_TipoEntidade("C");
                    // Linhas do documento para a lista de linhas
                    lstlindv = dv.LinhasDoc;
                    //PriEngine.Engine.Comercial.Vendas.PreencheDadosRelacionados(myEnc, rl);
                    PriEngine.Engine.Comercial.Vendas.PreencheDadosRelacionados(myEnc);
                    foreach (Model.LinhaDocVenda lin in lstlindv)
                    {
                        PriEngine.Engine.Comercial.Vendas.AdicionaLinha(myEnc, lin.CodArtigo, lin.Quantidade, "", "", lin.PrecoUnitario, lin.Desconto);
                    }


                   // PriEngine.Engine.Comercial.Compras.TransformaDocumento(

                    PriEngine.Engine.IniciaTransaccao();
                    //PriEngine.Engine.Comercial.Vendas.Edita Actualiza(myEnc, "Teste");
                    PriEngine.Engine.Comercial.Vendas.Actualiza(myEnc, "Teste");
                    PriEngine.Engine.TerminaTransaccao();
                    erro.Erro = 0;
                    erro.Descricao = "Sucesso";
                    return erro;
                }
                else
                {
                    erro.Erro = 1;
                    erro.Descricao = "Erro ao abrir empresa";
                    return erro;

                }

            }
            catch (Exception ex)
            {
                PriEngine.Engine.DesfazTransaccao();
                erro.Erro = 1;
                erro.Descricao = ex.Message;
                return erro;
            }
        }

     

        public static List<Model.DocVenda> Encomendas_List()
        {
            
            StdBELista objListCab;
            StdBELista objListLin;
            Model.DocVenda dv = new Model.DocVenda();
            List<Model.DocVenda> listdv = new List<Model.DocVenda>();
            Model.LinhaDocVenda lindv = new Model.LinhaDocVenda();
            List<Model.LinhaDocVenda> listlindv = new
            List<Model.LinhaDocVenda>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                objListCab = PriEngine.Engine.Consulta("SELECT id, Entidade, Data, NumDoc, TotalMerc, Serie From CabecDoc where TipoDoc='ECL'");
                while (!objListCab.NoFim())
                {
                    dv = new Model.DocVenda();
                    dv.id = objListCab.Valor("id");
                    dv.Entidade = objListCab.Valor("Entidade");
                    dv.NumDoc = objListCab.Valor("NumDoc");
                    dv.Data = objListCab.Valor("Data");
                    dv.TotalMerc = objListCab.Valor("TotalMerc");
                    dv.Serie = objListCab.Valor("Serie");
                    objListLin = PriEngine.Engine.Consulta("SELECT idCabecDoc, Artigo, Descricao, Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido from LinhasDoc where IdCabecDoc='" + dv.id + "' order By NumLinha");
                    listlindv = new List<Model.LinhaDocVenda>();

                    while (!objListLin.NoFim())
                    {
                        lindv = new Model.LinhaDocVenda();
                        lindv.IdCabecDoc = objListLin.Valor("idCabecDoc");
                        lindv.CodArtigo = objListLin.Valor("Artigo");
                        lindv.DescArtigo = objListLin.Valor("Descricao");
                        lindv.Quantidade = objListLin.Valor("Quantidade");
                        lindv.Unidade = objListLin.Valor("Unidade");
                        lindv.Desconto = objListLin.Valor("Desconto1");
                        lindv.PrecoUnitario = objListLin.Valor("PrecUnit");
                        lindv.TotalILiquido = objListLin.Valor("TotalILiquido");
                        lindv.TotalLiquido = objListLin.Valor("PrecoLiquido");

                        listlindv.Add(lindv);
                        objListLin.Seguinte();
                    }

                    dv.LinhasDoc = listlindv;
                    listdv.Add(dv);
                    objListCab.Seguinte();
                }
            }
            return listdv;
        }


       

        public static Model.DocVenda Encomenda_Get(string numdoc)
        {
            
            
            StdBELista objListCab;
            StdBELista objListLin;
            Model.DocVenda dv = new Model.DocVenda();
            Model.LinhaDocVenda lindv = new Model.LinhaDocVenda();
            List<Model.LinhaDocVenda> listlindv = new List<Model.LinhaDocVenda>();

            if (PriEngine.InitializeCompany(FirstREST.Properties.Settings.Default.Company.Trim(), FirstREST.Properties.Settings.Default.User.Trim(), FirstREST.Properties.Settings.Default.Password.Trim()) == true)
            {
                

                string st = "SELECT id, Entidade, Data, NumDoc, TotalMerc, Serie From CabecDoc where TipoDoc='ECL' and NumDoc='" + numdoc + "'";
                objListCab = PriEngine.Engine.Consulta(st);
                dv = new Model.DocVenda();
                dv.id = objListCab.Valor("id");
                dv.Entidade = objListCab.Valor("Entidade");
                dv.NumDoc = objListCab.Valor("NumDoc");
                dv.Data = objListCab.Valor("Data");
                dv.TotalMerc = objListCab.Valor("TotalMerc");
                dv.Serie = objListCab.Valor("Serie");
                objListLin = PriEngine.Engine.Consulta("SELECT idCabecDoc, Artigo, Descricao, Quantidade, Unidade, PrecUnit, Desconto1, TotalILiquido, PrecoLiquido from LinhasDoc where IdCabecDoc='" + dv.id + "' order By NumLinha");
                listlindv = new List<Model.LinhaDocVenda>();

                while (!objListLin.NoFim())
                {
                    lindv = new Model.LinhaDocVenda();
                    lindv.IdCabecDoc = objListLin.Valor("idCabecDoc");
                    lindv.CodArtigo = objListLin.Valor("Artigo");
                    lindv.DescArtigo = objListLin.Valor("Descricao");
                    lindv.Quantidade = objListLin.Valor("Quantidade");
                    lindv.Unidade = objListLin.Valor("Unidade");
                    lindv.Desconto = objListLin.Valor("Desconto1");
                    lindv.PrecoUnitario = objListLin.Valor("PrecUnit");
                    lindv.TotalILiquido = objListLin.Valor("TotalILiquido");
                    lindv.TotalLiquido = objListLin.Valor("PrecoLiquido");
                    listlindv.Add(lindv);
                    objListLin.Seguinte();
                }

                dv.LinhasDoc = listlindv;
                return dv;
            }
            return null;
        }

        #endregion DocsVenda

        public static Model.InfoArtigo infoArtigo(string codArtigo){
            StdBELista obj;
            Model.InfoArtigo artigo;

            if (
                !PriEngine.InitializeCompany(
                FirstREST.Properties.Settings.Default.Company.Trim(),
                FirstREST.Properties.Settings.Default.User.Trim(),
                FirstREST.Properties.Settings.Default.Password.Trim())
                ) return null;

            string query =
                "SELECT Artigo.Artigo, Artigo.STKActual, Artigo.STKReposicao,"+
                "Artigo.PCMedio, ArtigoMoeda.PVP1 FROM Artigo,ArtigoMoeda " +
                "WHERE Artigo.Artigo = '" + codArtigo + "' " +
                "AND Artigo.Artigo = ArtigoMoeda.Artigo";

            obj = PriEngine.Engine.Consulta(query);
            artigo = new Model.InfoArtigo
            {
                CodArtigo = obj.Valor("Artigo"),
                PCM = obj.Valor("PCMedio"),
                PVP = obj.Valor("PVP1"),
                STKAtual = obj.Valor("STKAtual"),
                STKReposicao = obj.Valor("STKReposicao")
            };

            return artigo;
        }

        public static List<Model.Compra> listaComprasDeArtigo(string codArtigo)
        {
            StdBELista obj;
            Model.Compra compra;
            List<Model.Compra> lista = new List<Model.Compra>();

            if (
                !PriEngine.InitializeCompany(
                FirstREST.Properties.Settings.Default.Company.Trim(),
                FirstREST.Properties.Settings.Default.User.Trim(),
                FirstREST.Properties.Settings.Default.Password.Trim())
                ) return null;

            string query =
                "SELECT CabecCompras.Entidade,LinhasCompras.Artigo," +
                "LinhasCompras.PrecUnit,LinhasCompras.Quantidade,CabecCompras.DataDoc " +
                "FROM CabecCompras,LinhasDoc " +
                "WHERE LinhasDoc.Artigo = '" + codArtigo + "' " +
                "AND LinhasCompras.IdCabecCompra = CabecCompras.Id " +
                "AND CabecCompras.TipoDoc = 'VFA'";

            obj = PriEngine.Engine.Consulta(query);

            while (!obj.NoFim())
            {
                compra = new Model.Compra
                {
                    Entidade = obj.Valor("Entidade"),
                    Artigo = obj.Valor("Artigo"),
                    PrecUnit = obj.Valor("PrecUnit"),
                    Quantidade = obj.Valor("Quantidade"),
                    DataDoc = obj.Valor("DataDoc")
                };

                lista.Add(compra);
            }
            
            return lista;
        }

        public static List<Model.Compra> listaComprasEncomendadasEmAtraso(string codArtigo)
        {
            StdBELista obj;
            Model.Compra compra;
            List<Model.Compra> lista = new List<Model.Compra>();

            if (
                !PriEngine.InitializeCompany(
                FirstREST.Properties.Settings.Default.Company.Trim(),
                FirstREST.Properties.Settings.Default.User.Trim(),
                FirstREST.Properties.Settings.Default.Password.Trim())
                ) return null;

            string query =
                "SELECT CabecCompras.Entidade,LinhasCompras.Artigo," +
                "LinhasCompras.PrecUnit,LinhasCompras.Quantidade,CabecCompras.DataDoc " +
                "FROM CabecCompras,LinhasDoc,LinhasComprasStatus  " +
                "WHERE LinhasDoc.Artigo = '" + codArtigo + "' " +
                "AND CabecCompras.TipoDoc = 'ECF' "+
                "AND LinhasCompras.IdCabecCompra = CabecCompras.Id  " +
                "AND LinhasComprasStatus.IdLinhasCompras = LinhasCompras.Id " +
                "AND LinhasComprasStatus.Quantidade != LinhasComprasStatus.QuantTrans";

            obj = PriEngine.Engine.Consulta(query);

            while (!obj.NoFim())
            {
                compra = new Model.Compra
                {
                    Entidade = obj.Valor("Entidade"),
                    Artigo = obj.Valor("Artigo"),
                    PrecUnit = obj.Valor("PrecUnit"),
                    Quantidade = obj.Valor("Quantidade"),
                    DataDoc = obj.Valor("DataDoc")
                };

                lista.Add(compra);
            }

            return lista;
        }

        public static List<Model.Venda> listaVendasEncomendadasEmAtraso(string codArtigo)
        {
            StdBELista obj;
            Model.Venda venda;
            List<Model.Venda> lista = new List<Model.Venda>();

            if (
                !PriEngine.InitializeCompany(
                FirstREST.Properties.Settings.Default.Company.Trim(),
                FirstREST.Properties.Settings.Default.User.Trim(),
                FirstREST.Properties.Settings.Default.Password.Trim())
                ) return null;

            string query =
                "SELECT CabecCompras.Entidade,LinhasCompras.Artigo," +
                "LinhasCompras.PrecUnit,LinhasCompras.Quantidade,CabecCompras.DataDoc " +
                "FROM CabecCompras,LinhasDoc,LinhasDocStatus  " +
                "WHERE LinhasDoc.Artigo = '" + codArtigo + "' " +
                "AND CabecDoc.TipoDoc = 'ECL' " +
                "AND LinhasDoc.IdCabecDoc = CabecDoc.Id " +
                "AND LinhasDocStatus.IdLinhasDoc = LinhasDoc.Id " +
                "AND LinhasDocStatus.Quantidade != LinhasDocStatus.QuantTrans";

            obj = PriEngine.Engine.Consulta(query);

            while (!obj.NoFim())
            {
                venda = new Model.Venda
                {
                    Entidade = obj.Valor("Entidade"),
                    Artigo = obj.Valor("Artigo"),
                    PrecUnit = obj.Valor("PrecUnit"),
                    Quantidade = obj.Valor("Quantidade")
                };

                lista.Add(venda);
            }

            return lista;
        }              
    
    }
}