﻿using Hmcr.Data.Repositories;
using Hmcr.Model;
using Hmcr.Model.Dtos;
using Hmcr.Model.Dtos.SubmissionObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Hmcr.Domain.Services
{
    public interface ISubmissionObjectService
    {
        Task<SubmissionObjectDto> GetSubmissionObjectAsync(decimal submissionObjectId);
        Task<PagedDto<SubmissionObjectSearchDto>> GetSubmissionObjectsAsync(decimal serviceAreaNumber, DateTime dateFrom, DateTime dateTo, int pageSize, int pageNumber, string searchText, string orderBy, string direction);
        Task<SubmissionObjectResultDto> GetSubmissionResultAsync(decimal submissionObjectId);
        Task<SubmissionObjectFileDto> GetSubmissionFileAsync(decimal submissionObjectId);
        Task<(SubmissionDto submission, byte[] file)> ExportSubmissionCsvAsync(decimal submissionObjectId);
    }
    public class SubmissionObjectService : ISubmissionObjectService
    {
        private ISubmissionObjectRepository _submissionRepo;
        private IWorkReportService _workRptService;

        public SubmissionObjectService(ISubmissionObjectRepository submissionRepo, IWorkReportService workRptService)
        {
            _submissionRepo = submissionRepo;
            _workRptService = workRptService;
        }

        public async Task<SubmissionObjectDto> GetSubmissionObjectAsync(decimal submissionObjectId)
        {
            return await _submissionRepo.GetSubmissionObjectAsync(submissionObjectId);
        }

        public async Task<PagedDto<SubmissionObjectSearchDto>> GetSubmissionObjectsAsync(decimal serviceAreaNumber, DateTime dateFrom, DateTime dateTo, int pageSize, int pageNumber, string searchText, string orderBy, string direction)
        {
            return await _submissionRepo.GetSubmissionObjectsAsync(serviceAreaNumber, dateFrom, dateTo, pageSize, pageNumber, searchText, orderBy, direction);
        }

        public async Task<SubmissionObjectResultDto> GetSubmissionResultAsync(decimal submissionObjectId)
        {
            return await _submissionRepo.GetSubmissionResultAsync(submissionObjectId);
        }

        public async Task<SubmissionObjectFileDto> GetSubmissionFileAsync(decimal submissionObjectId)
        {
            return await _submissionRepo.GetSubmissionFileAsync(submissionObjectId);
        }

        public async Task<(SubmissionDto submission, byte[] file)> ExportSubmissionCsvAsync(decimal submissionObjectId)
        {
            var submission = await _submissionRepo.GetSubmissionInfoForExportAsync(submissionObjectId);

            switch (submission.StagingTableName)
            {
                case TableNames.WorkReport:
                    return (submission, await _workRptService.ExportToCsv(submissionObjectId));
                default:
                    throw new NotImplementedException($"Background job for {submission.StagingTableName} is not implemented.");
            }
        }
    }
}
