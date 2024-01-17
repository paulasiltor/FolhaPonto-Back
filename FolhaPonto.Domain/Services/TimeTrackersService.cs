using FolhaPonto.Domain.Interfaces;
using FolhaPonto.Domain.Models;
using FolhaPonto.Domain.Resquest;
using System.Reflection.Metadata.Ecma335;

namespace FolhaPonto.Domain.Services
{
    public class TimeTrackersService : ITimeTrackersService
    {
        private readonly ITimeTrackersRepository _timeTrackersRepository;

        public TimeTrackersService(ITimeTrackersRepository timeTrackersRepository)
        {
            _timeTrackersRepository = timeTrackersRepository;
        }

        public async Task<IEnumerable<TimeTrackers>> BuscarAll()
        {
            return await _timeTrackersRepository.GetAll();
        }

        public async Task<TimeTrackers> BuscarId(Guid timeTrackersId)
        {
            return await _timeTrackersRepository.GetById(timeTrackersId);
        }

        public async Task<bool> Post(TimeTrackersRequest request)
        {
            if (await RegraIntervaloAnd24Hrs(request.TasksId, request.StartDate, request.EndDate) == false)
                return false;

            TimeTrackers timers = new()
            {
                StartDate = request.StartDate,
                EndDate = request.EndDate,
                TimeZoneId = request.TimeZoneId,
                TasksId = request.TasksId,
                CollaboratorsId = request.CollaboratorsId,
                CreatedAt = DateTime.UtcNow,
                UpdateAt = DateTime.UtcNow
            };

            _timeTrackersRepository.Add(timers);

            return true;
        }

        public async Task<TimeTrackers?> Put(Guid timeTrackersId, TimeTrackersRequest request)
        {
            var item = await BuscarId(timeTrackersId);

            if (await RegraIntervaloAnd24Hrs(item.TasksId, request.StartDate, request.EndDate) == false)
                return null;

            if (item != null)
            {
                item.StartDate = request.StartDate;
                item.EndDate = request.EndDate;
                item.TimeZoneId = request.TimeZoneId;
                item.TasksId = request.TasksId;
                item.CollaboratorsId = request.CollaboratorsId;
                item.CreatedAt = DateTime.UtcNow;
                item.UpdateAt = DateTime.UtcNow;

                _timeTrackersRepository.Update(item);
            }

            return item;
        }

        public async Task<TimeTrackers> Delete(Guid timeTrackersId)
        {
            var item = await BuscarId(timeTrackersId);

            if (item != null)
            {
                item.DeleteAt = DateTime.UtcNow;
                item.UpdateAt = DateTime.Now;

                _timeTrackersRepository.Update(item);
            }

            return item;
        }

        private static bool EstaDentroDoIntervalo(DateTime dataVerificar, DateTime dataInicial, DateTime dataFinal)
        {
            return dataVerificar >= dataInicial && dataVerificar <= dataFinal;
        }

        private async Task<bool> RegraIntervaloAnd24Hrs(Guid taskId, DateTime dataInicio, DateTime dataFim)
        {
            var timesWithTaskId = await _timeTrackersRepository.GetByTask(taskId);
            float hrsTotal = dataInicio.Hour + dataFim.Hour;

            foreach (var times in timesWithTaskId)
            {
                hrsTotal += times.StartDate.Hour + times.EndDate.Hour;

                if (hrsTotal < 24)
                {
                    if (!EstaDentroDoIntervalo(dataInicio, times.StartDate, times.EndDate))
                        if (EstaDentroDoIntervalo(dataFim, times.StartDate, times.EndDate))
                            return false;
                }
            }

            return true;
        }
    }
}
