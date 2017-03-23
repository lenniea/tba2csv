using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;

using Newtonsoft.Json.Linq;

namespace tba2csv
{
    class Match
    {
        public string key;
        public long time;
        public short match;

        protected Info _red;
        public Info red
        {
            get { return _red; }    // Read-only
        }
        protected Info _blue;
        public Info blue
        {
            get { return _blue; }   // Read-only
        }

        public class Info
        {
            public string key, team1, team2, team3;
            public short score;

            public string robot1Auto, robot2Auto, robot3Auto;
#if STRONGHOLD
            public short autoBouldersLow, autoBouldersHigh;

            public short pos1crossings, pos2crossings, pos3crossings, pos4crossings, pos5crossings;
            public string pos2, pos3, pos4, pos5;

            public short teleopDefensesBreached;
            public short teleopBouldersLow, teleopBouldersHigh;
            public short towerEndStrength, teleopTowerCaptured;

            public string towerFaceA, towerFaceB, towerFaceC;

            public short autoReachPoints, autoCrossingPoints, autoBoulderPoints;

            public short teleopCrossingPoints, breachPoints, teleopBoulderPoints;
            public short capturePoints, teleopChallengePoints, teleopScalePoints;
            public short foulPoints, adjustPoints;
#else
            public short autoRotorPoints, autoFuelHigh, autoFuelLow;
            public bool rotor1Auto, rotor2Auto;
            public short autoMobilityPoints, autoFuelPoints;

            public short teleopFuelHigh, teleopFuelLow;
            public short teleopRotorPoints, teleopFuelPoints, teleopTakeoffPoints;
            public bool rotor1Engaged, rotor2Engaged, rotor3Engaged, rotor4Engaged;
            public string touchpadFar, touchpadNear, touchpadMiddle;
            public bool kPaRankingPoint, rotorRankingPoint;
            public short kPaBonusPoints, rotorBonusPoints;
#endif
            public short foulCount, techFoulCount;
            public short autoPoints, teleopPoints;

            public void ParseJson(string str)
            {
                JObject o = JObject.Parse(str);
                foreach (JProperty p in o.Properties())
                {
                    string name = p.Name;
                    string value = p.Value.ToString();
                    switch (name)
                    {
                        case "robot1Auto":
                            robot1Auto = value;
                            break;
                        case "robot2Auto":
                            robot2Auto = value;
                            break;
                        case "robot3Auto":
                            robot3Auto = value;
                            break;
#if STRONGHOLD
                        case "autoBouldersLow":
                            autoBouldersLow = (short)p.Value;
                            break;
                        case "autoBouldersHigh":
                            autoBouldersHigh = (short)p.Value;
                            break;

                        case "position1crossings":
                            pos1crossings = (short)p.Value;
                            break;
                        case "position2crossings":
                            pos2crossings = (short)p.Value;
                            break;
                        case "position3crossings":
                            pos3crossings = (short)p.Value;
                            break;
                        case "position4crossings":
                            pos4crossings = (short)p.Value;
                            break;
                        case "position5crossings":
                            pos5crossings = (short)p.Value;
                            break;
                        case "position2":
                            pos2 = value;
                            break;
                        case "position3":
                            pos3 = value;
                            break;
                        case "position4":
                            pos4 = value;
                            break;
                        case "position5":
                            pos5 = value;
                            break;

                        case "teleopDefensesBreached":
                            teleopDefensesBreached = (short)p.Value;
                            break;

                        case "teleopBouldersLow":
                            teleopBouldersLow = (short)p.Value;
                            break;
                        case "teleopBouldersHigh":
                            teleopBouldersHigh = (short)p.Value;
                            break;

                        case "towerEndStrength":
                            towerEndStrength = (short)p.Value;
                            break;
                        case "teleopTowerCaptured":
                            teleopTowerCaptured = (short)p.Value;
                            break;

                        case "towerFaceA":
                            towerFaceA = value;
                            break;
                        case "towerFaceB":
                            towerFaceB = value;
                            break;
                        case "towerFaceC":
                            towerFaceC = value;
                            break;

                        case "autoReachPoints":
                            autoReachPoints = (short)p.Value;
                            break;
                        case "autoCrossingPoints":
                            autoCrossingPoints = (short)p.Value;
                            break;
                        case "autoBoulderPoints":
                            autoBoulderPoints = (short)p.Value;
                            break;

                        case "teleopCrossingPoints":
                            teleopCrossingPoints = (short)p.Value;
                            break;

                        case "breachPoints":
                            breachPoints = (short)p.Value;
                            break;
                        case "teleopBoulderPoints":
                            teleopBoulderPoints = (short)p.Value;
                            break;
                        case "teleopPoints":
                            teleopPoints = (short)p.Value;
                            break;

                        case "capturePoints":
                            capturePoints = (short)p.Value;
                            break;
                        case "teleopChallengePoints":
                            teleopChallengePoints = (short)p.Value;
                            break;
                        case "teleopScalePoints":
                            teleopScalePoints = (short)p.Value;
                            break;
#else
                        case "autoFuelLow":
                            autoFuelLow = (short)p.Value;
                            break;
                        case "autoFuelHigh":
                            autoFuelHigh = (short)p.Value;
                            break;
                        case "autoMobilityPoints":
                            autoMobilityPoints = (short)p.Value;
                            break;
                        case "autoFuelPoints":
                            autoFuelPoints = (short)p.Value;
                            break;
                        case "rotor1Auto":
                            rotor1Auto = (bool) p.Value;
                            break;
                        case "rotor2Auto":
                            rotor2Auto = (bool) p.Value;
                            break;
                        case "autoRotorPoints":
                            autoRotorPoints = (short)p.Value;
                            break;

                        case "teleopFuelLow":
                            teleopFuelLow = (short)p.Value;
                            break;
                        case "teleopFuelHigh":
                            teleopFuelHigh = (short)p.Value;
                            break;
                        case "teleopFuelPoints":
                            teleopFuelPoints = (short)p.Value;
                            break;
                        case "teleopRotorPoints":
                            teleopRotorPoints = (short)p.Value;
                            break;
                        case "teleopTakeoffPoints":
                            teleopTakeoffPoints = (short)p.Value;
                            break;

                        case "rotor1Engaged":
                            rotor1Engaged = (bool)p.Value;
                            break;
                        case "rotor2Engaged":
                            rotor2Engaged = (bool)p.Value;
                            break;
                        case "rotor3Engaged":
                            rotor3Engaged = (bool)p.Value;
                            break;
                        case "rotor4Engaged":
                            rotor4Engaged = (bool)p.Value;
                            break;

                        case "touchpadFar":
                            touchpadFar = (string) p.Value;
                            break;
                        case "touchpadNear":
                            touchpadNear = (string)p.Value;
                            break;
                        case "touchpadMiddle":
                            touchpadMiddle = (string)p.Value;
                            break;

                        case "rotorRankingPointAchieved":
                            rotorRankingPoint = (bool)p.Value;
                            break;
                        case "kPaRankingPointAchieved":
                            kPaRankingPoint  = (bool)p.Value;
                            break;
                        case "rotorBonusPoints":
                            rotorBonusPoints = (short)p.Value;
                            break;
                        case "kPaBonusPoints":
                            kPaBonusPoints = (short)p.Value;
                            break;

#endif
                        case "autoPoints":
                            autoPoints = (short)p.Value;
                            break;
                        case "foulCount":
                            foulCount = (short)p.Value;
                            break;
                        case "techFoulCount":
                            techFoulCount = (short)p.Value;
                            break;
                        case "teleopPoints":
                            teleopPoints = (short)p.Value;
                            break;

                        case "totalPoints":
                            score = (short)p.Value;
                            break;
                        default:
                            Debug.WriteLine("UNKNOWN " + name + ":" + value);
                            break;
                    }
                }
            }
            public void ParseJsonTeams(string str, Info team)
            {
                JObject o = JObject.Parse(str);
                foreach (JProperty p in o.Properties())
                {
                    string name = p.Name;
                    string value = p.Value.ToString();
                    switch (name)
                    {
                        case "red1":
                        case "blue1":
                            team.team1 = value;
                            break;
                        case "red2":
                        case "blue2":
                            team.team2 = value;
                            break;
                        case "red3":
                        case "blue3":
                            team.team3 = value;
                            break;
                        default:
                            Debug.WriteLine("IGNORING " + name + ':' + value);
                            break;
                    }
                }
            }
            // Convert the fields to string[] array
            public string[] ToStrings()
            {
                string[] sa = new string[42];
                sa[0] = key;
                sa[1] = team1;
                sa[2] = team2;
                sa[3] = team3;
                sa[4] = score.ToString();
                sa[5] = robot1Auto;
                sa[6] = robot2Auto;
                sa[7] = robot3Auto;
#if STRONGHOLD
                sa[8] = autoBouldersLow.ToString();
                sa[9] = autoBouldersHigh.ToString();
                sa[10] = pos1crossings.ToString();
                sa[11] = pos2crossings.ToString(); ;
                sa[12] = pos3crossings.ToString(); ;
                sa[13] = pos4crossings.ToString(); ;
                sa[14] = pos5crossings.ToString(); ;
                sa[15] = pos2;
                sa[16] = pos3;
                sa[17] = pos4;
                sa[18] = pos5;

                sa[19] = teleopDefensesBreached.ToString();
                sa[20] = teleopBouldersLow.ToString();
                sa[21] = teleopBouldersHigh.ToString();

                sa[22] = towerEndStrength.ToString();
                sa[23] = teleopTowerCaptured.ToString();

                sa[24] = towerFaceA;
                sa[25] = towerFaceB;
                sa[26] = towerFaceC;

                sa[27] = foulCount.ToString();
                sa[28] = techFoulCount.ToString();

                sa[29] = autoReachPoints.ToString();
                sa[30] = autoCrossingPoints.ToString();
                sa[31] = autoBoulderPoints.ToString();
                sa[32] = autoPoints.ToString();

                sa[33] = teleopCrossingPoints.ToString();
                sa[34] = breachPoints.ToString();
                sa[35] = teleopBoulderPoints.ToString();
                sa[36] = teleopPoints.ToString();

                sa[37] = capturePoints.ToString();
                sa[38] = teleopChallengePoints.ToString();
                sa[39] = teleopScalePoints.ToString();
                sa[40] = foulPoints.ToString();
                sa[41] = adjustPoints.ToString();
#else
                sa[8] = autoRotorPoints.ToString();
                sa[9] = autoFuelHigh.ToString();
                sa[10] = autoFuelLow.ToString();
                sa[11] = rotor1Auto.ToString();
                sa[12] = rotor2Auto.ToString();
                sa[13] = autoMobilityPoints.ToString();
                sa[14] = autoFuelPoints.ToString();

                sa[15] = teleopFuelHigh.ToString();
                sa[16] = teleopFuelLow.ToString();
                sa[17] = teleopRotorPoints.ToString();
                sa[18] = teleopFuelPoints.ToString();
                sa[19] = teleopTakeoffPoints.ToString();
                sa[20] = rotor1Engaged.ToString();
                sa[21] = rotor2Engaged.ToString();
                sa[22] = rotor3Engaged.ToString();
                sa[23] = rotor4Engaged.ToString();
                sa[24] = touchpadFar.ToString();
                sa[25] = touchpadNear.ToString();
                sa[26] = touchpadMiddle.ToString();
                sa[27] = kPaRankingPoint.ToString();
                sa[28] = rotorRankingPoint.ToString();
                sa[29] = kPaBonusPoints.ToString();
                sa[30] = rotorBonusPoints.ToString();
#endif
                return sa;
            }

            // Format string[] array into CSV string
            public static string FormatCSV(char sep, string[] values)
            {
                string str = null;
                int count = values.Length;
                if (count > 0)
                {
                    str = values[0];
                    for (int i = 1; i < count; ++i)
                    {
                        str += sep + values[i];
                    }
                }
                return str;
            }
        }

        public void ParseJsonScore(string str)
        {
            JObject o = JObject.Parse(str);
            foreach (JProperty p in o.Properties())
            {
                string name = p.Name;
                string value = p.Value.ToString();
                switch (name)
                {
                    case "blue":
                        _blue = new Info();
                        _blue.key = key;
                        _blue.ParseJson(value);
                        break;
                    case "red":
                        _red = new Info();
                        _red.key = key;
                        _red.ParseJson(value);
                        break;
                    default:
                        Debug.WriteLine(name + ":" + value);
                        throw new Exception("invalid name" + p.Name);
                }
            }
        }

        public void ParseJsonTeam(string str, Info team)
        {
            JObject o = JObject.Parse(str);
            foreach (JProperty p in o.Properties())
            {
                string name = p.Name;
                string value = p.Value.ToString();
                switch (name)
                {
                    case "score":
                        team.score = (short)p.Value;
                        break;
                    case "teams":
                        JArray a = JArray.Parse(value);
                        team.team1 = a[0].ToString();
                        team.team2 = a[1].ToString();
                        team.team3 = a[2].ToString();
                        break;
                    default:
                        Debug.WriteLine("Ignored: " + name + ':' + value);
                        break;
                }
            }
        }

        public void ParseJsonAlliances(string str)
        {
            JObject o = JObject.Parse(str);
            foreach (JProperty p in o.Properties())
            {
                string name = p.Name;
                string value = p.Value.ToString();
                switch (name)
                {
                    case "blue":
                        if (blue != null) ParseJsonTeam(value, blue);
                        break;
                    case "red":
                        if (red != null) ParseJsonTeam(value, red);
                        break;
                }
            }
        }

        public string[] headers = 
        {
            "Key",
            "Team1", "Team2", "Team3",
            "Score",
            // Autonomous
            "Robot1Auto","Robot2Auto","Robot3Auto",
#if STRONGHOLD
            "BouldersLow","BouldersHigh",

            // Defenses
            "Pos1cross","Pos2cross","Pos3cross","Pos4cross","Pos5cross",
            "Pos2","Pos3","Pos4","Pos5",

            // Teleop
            "DefensesBreached",
            "BouldersLow","BouldersHigh",
            "TowerStrength","TowerCaptured",

            "TowerFaceA","TowerFaceB","TowerFaceC",
            "FoulCount","TechFoulCount",

            "ReachPoints","CrossPoints","BoulderPoints","AutoPoints",

            "CrossingPoints","Points","BoulderPoints","TeleopPoints",

            "CapturePoints","ChallengePoints","ScalePoints",
            "FoulPoints","AdjustPoints"
#else
            // Autonomous
            "autoRotorPoints", "autoFuelHigh", "autoFuelLow",
            "rotor1Auto", "rotor2Auto",
            "autoMobilityPoints", "autoFuelPoints",

            // Teleop
            "teleopFuelHigh", "teleopFuelLow",
            "teleopRotorPoints", "teleopFuelPoints", "teleopTakeoffPoints",
            "rotor1Engaged", "rotor2Engaged", "rotor3Engaged", "rotor4Engaged",
            "touchpadFar", "touchpadNear", "touchpadMiddle",
            "kPaRankingPoint", "rotorRankingPoint",
            "kPaBonusPoints", "rotorBonusPoints",
#endif
        };

        /// <summary>
        /// Parse a JSON formatted match
        /// </summary>
        /// <param name="str"></param>
        /// <returns>Match</returns> Array of Match Info and Headers
        public int ParseJson(string str, out Match[] matches)
        {
            JArray a = JArray.Parse(str);
            int count = a.Count;
            matches = new Match[count];
            int row = 0;
            foreach (JObject o in a.Children<JObject>())
            {
                matches[row] = new Match();
                foreach (JProperty p in o.Properties())
                {
                    string name = p.Name;
                    string value = p.Value.ToString();
                    switch (name)
                    {
                        case "score_breakdown":
                            if (value.Length > 0) matches[row].ParseJsonScore(value);
                            break;
                        case "alliances":
                            matches[row].ParseJsonAlliances(value);
                            break;
                        case "key":
                            matches[row].key = value;
                            break;
                        case "time":
                            matches[row].time = Int32.Parse(value);
                            break;
                        case "match":
                            matches[row].match = Int16.Parse(value);
                            break;
                        default:
                            Debug.WriteLine("IGNORED " + name + ':' + value);
                            break;
                    }
                }
                ++row;
            }
            return count;
        }
    }
};
