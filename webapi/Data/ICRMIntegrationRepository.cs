using System;
using System.Collections.Generic;
using webapi.Models;

namespace webapi.Data
{
    public interface ICRMIntegrationRepository
    {
        CRMIntegration GetCRMIntegrationById(int integrationId);
        List<CRMIntegration> GetCRMIntegrationByUserId(int userId);
        void AddCRMIntegration(CRMIntegration integration);
        void UpdateCRMIntegration(CRMIntegration integration);
        void DeleteCRMIntegration(int integrationId);
    }
}
