using NLog;
using System;
using System.Net;
using AutoMapper;
using System.Linq;
using System.Web.Http;
using System.Collections.Generic;
using MCWH.CompanyManager.API.Models;
using MCWH.CompanyManager.Service.Company;
using dataModels = MCWH.CompanyManager.Data;

namespace MCWH.CompanyManager.API.Controllers
{
    public class CompanyController : ApiController
    {
        #region Private Variables
        private readonly ICompanyService _companyService;
        private readonly Logger logger = LogManager.GetCurrentClassLogger();
        #endregion

        #region Constructor
        public CompanyController(ICompanyService companyService)
        {
            _companyService = companyService;
        }
        #endregion

        [Route("api/companies/{id:int}")]
        [HttpGet]
        public IHttpActionResult Get(int id)
        {
            logger.Info($"Begin Company Get request.");

            try
            {
                var company = _companyService.Get(id).FirstOrDefault();

                return Ok(Mapper.Map<CompanyViewModel>(company));
            }
            catch (Exception ex)
            {
                logger.Error($"UnExpected exception encountered while processing company get request. Details : {ex.ToString()}");
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            finally
            {
                logger.Info($"End Company Get request.");
            }
        }

        [Route("api/companies")]
        [HttpGet]
        public IHttpActionResult Get()
        {
            logger.Info($"Begin Company Get request.");

            try
            {
                var companies = _companyService.Get();

                return Ok(Mapper.Map<List<CompanyViewModel>>(companies));
            }
            catch (Exception ex)
            {
                logger.Error($"UnExpected exception encountered while processing company get request. Details : {ex.ToString()}");
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            finally
            {
                logger.Info($"End Company Get request.");
            }
        }

        [Route("api/companies/{id:int?}")]
        [HttpPost]
        public IHttpActionResult Post(CompanyViewModel companyViewModel)
        {
            logger.Info($"Begin Company Edit. Request : {Json(companyViewModel)}");

            try
            {
                if (ModelState.IsValid)
                {
                    var company = Mapper.Map<dataModels.Company>(companyViewModel);
                    var status = _companyService.CreateOrUpdate(company);

                    return Ok(status);
                }
                else
                {
                    return BadRequest(ModelState);
                }
            }
            catch (Exception ex)
            {
                logger.Error($"Unexpected exception encountered while processing company edit request. Details : {ex.ToString()}");
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            finally
            {
                logger.Info($"End company edit.");
            }
        }

        [Route("api/companies/{id:int}")]
        [HttpDelete]
        public IHttpActionResult Delete(int id)
        {
            logger.Info($"Begin company delete.");

            try
            {
                var status = _companyService.Delete(id);

                return Ok(status);
            }
            catch (Exception ex)
            {
                logger.Error($"UnExpected exception encountered while processing this request. Details : {ex.ToString()}");
                return StatusCode(HttpStatusCode.InternalServerError);
            }
            finally
            {
                logger.Info($"End Company delete.");
            }
        }
    }
}
