using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {
        public async Task<List<string>> InitializeList(IEnumerable<string> items)
        {
            var tasks = items.Select(async i =>
            {
                var result = await Task.Run(() => i).ConfigureAwait(false);
                return result;
            });

            var results = await Task.WhenAll(tasks).ConfigureAwait(false);
            return results.ToList();
        }

        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            var concurrentDictionary = new ConcurrentDictionary<int, string>();
            Parallel.ForEach(Enumerable.Range(0, 100), item =>
            {
                concurrentDictionary.AddOrUpdate(item, getItem, (_, s) => s);
            });

            return concurrentDictionary.ToDictionary(kv => kv.Key, kv => kv.Value);
        }

    }
}