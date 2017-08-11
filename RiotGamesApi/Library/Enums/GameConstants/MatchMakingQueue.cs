namespace RiotGamesApi.Library.Enums.GameConstants
{
    /// <summary>
    /// for matchlist and league queries 
    /// </summary>
    public enum MatchMakingQueue
    {
        UNDEFINED = -1,

        //Custom games
        CUSTOM = 0,

        //Normal 3v3 games
        NORMAL_3x3 = 8,

        //Normal 5v5 Blind Pick games
        NORMAL_5x5_BLIND = 2,

        //Normal 5v5 Draft Pick games
        NORMAL_5x5_DRAFT = 14,

        //Ranked Solo 5v5 games
        RANKED_SOLO_5x5 = 4,

        //Ranked Premade 5v5 games
        RANKED_PREMADE_5x5 = 6,

        //Used for both historical Ranked Premade 3v3 games and current Ranked Flex Twisted Treeline games
        RANKED_FLEX_TT = 9,

        //Ranked Team 3v3 games
        RANKED_TEAM_3x3 = 41,

        //Ranked Team 5v5 games
        RANKED_TEAM_5x5 = 42,

        //Dominion 5v5 Blind Pick games
        ODIN_5x5_BLIND = 16,

        //Dominion 5v5 Draft Pick games
        ODIN_5x5_DRAFT = 17,

        //Historical Summoner's Rift Coop vs AI games
        BOT_5x5 = 7,

        //Dominion Coop vs AI games
        BOT_ODIN_5x5 = 25,

        //Summoner's Rift Coop vs AI Intro Bot games
        BOT_5x5_INTRO = 31,

        //Summoner's Rift Coop vs AI Beginner Bot games
        BOT_5x5_BEGINNER = 32,

        //Historical Summoner's Rift Coop vs AI Intermediate Bot games
        BOT_5x5_INTERMEDIATE = 33,

        //Twisted Treeline Coop vs AI games
        BOT_TT_3x3 = 52,

        //Team Builder games
        GROUP_FINDER_5x5 = 61,

        //ARAM games
        ARAM_5x5 = 65,

        //One for All games
        ONEFORALL_5x5 = 70,

        //Snowdown Showdown 1v1 games
        FIRSTBLOOD_1x1 = 72,

        //Snowdown Showdown 2v2 games
        FIRSTBLOOD_2x2 = 73,

        //Summoner's Rift 6x6 Hexakill games
        SR_6x6 = 75,

        //Ultra Rapid Fire games
        URF_5x5 = 76,

        //One for All (Mirror mode)
        ONEFORALL_MIRRORMODE_5x5 = 78,

        //Ultra Rapid Fire games played against AI games
        BOT_URF_5x5 = 83,

        //Doom Bots Rank 1 games
        NIGHTMARE_BOT_5x5_RANK1 = 91,

        //Doom Bots Rank 2 games
        NIGHTMARE_BOT_5x5_RANK2 = 92,

        //Doom Bots Rank 5 games
        NIGHTMARE_BOT_5x5_RANK5 = 93,

        //Ascension games
        ASCENSION_5x5 = 96,

        //Twisted Treeline 6x6 Hexakill games
        HEXAKILL = 98,

        //Butcher's Bridge games
        BILGEWATER_ARAM_5x5 = 100,

        //King Poro games
        KING_PORO_5x5 = 300,

        //Nemesis games
        COUNTER_PICK = 310,

        //Black Market Brawlers games
        BILGEWATER_5x5 = 313,

        //Nexus Siege games
        SIEGE = 315,

        //Definitely Not Dominion games
        DEFINITELY_NOT_DOMINION_5x5 = 317,

        //All Random URF games
        ARURF_5X5 = 318,

        //All Random Summoner's Rift games
        ARSR_5x5 = 325,

        //Normal 5v5 Draft Pick games
        TEAM_BUILDER_DRAFT_UNRANKED_5x5 = 400,

        //Ranked 5v5 Draft Pick games
        TEAM_BUILDER_DRAFT_RANKED_5x5 = 410,

        //Ranked Solo games from current season that use Team Builder matchmaking
        TEAM_BUILDER_RANKED_SOLO = 420,

        //Normal 5v5 Blind Pick games
        TB_BLIND_SUMMONERS_RIFT_5x5 = 430,

        //Ranked Flex Summoner's Rift games
        RANKED_FLEX_SR = 440,

        //Blood Hunt Assassin games
        ASSASSINATE_5x5 = 600,

        //Dark Star games
        DARKSTAR_3x3 = 610,
    }
}