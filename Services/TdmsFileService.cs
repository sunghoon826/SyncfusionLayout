using SyncfusionLayout.Interfaces;
using SyncfusionLayout.Models;
using Microsoft.EntityFrameworkCore;
namespace SyncfusionLayout.Services
{
    public class TdmsFileService : IDatabase<TdmsFile>
    {
        private readonly TdmsFilesContext _context;

        public TdmsFileService(TdmsFilesContext context)
        {
            _context = context;
        }

        public async Task<List<TdmsFile>> GetAsync(DateTime? date = null)
        {
            if (!date.HasValue)
            {
                // 날짜가 제공되지 않았으므로 빈 리스트 반환
                return new List<TdmsFile>();
            }

            // 제공된 날짜에 해당하는 데이터만 조회
            var targetDate = date.Value.Date; // 날짜 부분만 가져오기
            return await _context.TdmsFiles
                                 .Where(file => file.Date.Date == targetDate)
                                 .ToListAsync();
        }


        public TdmsFile GetDetail(int? id)
        {
            if (id == null)
            {
                throw new ArgumentNullException(nameof(id), "ID cannot be null.");
            }

            return _context.TdmsFiles.Find(id);
        }
    }


    public class ChartData
    {
        public double Time { get; set; }
        public double Value { get; set; }
    }
}

