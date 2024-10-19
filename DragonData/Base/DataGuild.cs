﻿using Discord.WebSocket;
using DragonData.Context;
using DragonData.Module;
using Microsoft.EntityFrameworkCore;

namespace DragonData.Base
{
    public class DataGuild : DataBase
    {
        public DataGuild(IDbContextFactory<DatabaseContext> context) : base(context)
        {
        }


        /// <summary>
        /// 
        /// </summary>
        /// <param name="ID"></param>
        /// <returns></returns>
        public async Task<bool> DataCheckGuild(ulong ID)
        {
            using var context = contextFactoryData.CreateDbContext();
            var query = context.Guilds.Where(x => x.guildID == ID);

            return await query.AnyAsync();
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guild"></param>
        /// <returns></returns>
        private async Task<GuildModule> CreateGuild(SocketGuild guild)
        {
            using var context = contextFactoryData.CreateDbContext();
            GuildModule itemGuild;
            itemGuild = new GuildModule
            {
                guildID = guild.Id,
                guildName = guild.Name
            };
            context.Add(itemGuild);
            await context.SaveChangesAsync();
            return itemGuild;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="guild"></param>
        /// <returns></returns>
        private async Task<GuildModule> GetGuild(SocketGuild guild)
        {
            using var context = contextFactoryData.CreateDbContext();
            var dataGuildQuery = context.Guilds.Where(x => x.guildID == guild.Id);
            GuildModule itemGuild = await dataGuildQuery.FirstAsync();
            return itemGuild;
        }

        public async Task<GuildModule> GetAndCreateDataGuild(SocketGuild guild)
        {
            GuildModule dataGuild;
            var _blocklist = new DataBlocklist(contextFactoryData);

            if (await DataCheckGuild(guild.Id) != false)
            {
                return await GetGuild(guild);
            }

            dataGuild = await CreateGuild(guild);
            foreach (var itemTagName in DataBlocklist._globalBlockList)
            {
                await _blocklist.SetBlocklistForGuild(guild, dataGuild, itemTagName);
            }
            return dataGuild;

        }
    }
}