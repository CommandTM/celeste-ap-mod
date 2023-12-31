﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Celeste.Mod.APCeleste
{
    public class APCelesteIDSheet
    {
        public Dictionary<string,int> BerryIDToWorldID { get; }
        public Dictionary<int, int> CassetteIDToWorldID { get; }
        public Dictionary<string, int> HeartIDToWorldID { get; }

        public APCelesteIDSheet()
        {
            BerryIDToWorldID = new Dictionary<string, int> // Big Berry Dictonary, Used to translate Berry IDs to AP IDs
            {
                // 1A
                {"2:11", 69000000},
                {"3:9", 69000001},
                {"3b:2", 69000002},
                {"5z:10", 69000003},
                {"5:21", 69000004},
                {"5a:2", 69000005},
                {"7zb:2", 69000006},
                {"6:12", 69000007},
                {"s1:9", 69000008},
                {"7z:3", 69000009},
                {"8zb:1", 69000010},
                {"7a:12", 69000011},
                {"9z:3", 69000012},
                {"8b:1", 69000013},
                {"9:14", 69000014},
                {"10zb:1", 69000015},
                {"11:9", 69000016},
                {"9b:9", 69000017},
                {"9c:2", 69000018},
                {"12z:8", 69000019},

                // 2A
                {"d3:10", 69000022},
                {"d2:9", 69000023},
                {"d1:67", 69000024},
                {"d6:2", 69000025},
                {"d0:6", 69000026},
                {"d4:6", 69000027},
                {"d5:12", 69000028},
                {"d2:31", 69000029},
                {"1:1", 69000030},
                {"4:4", 69000032},
                {"5:15", 69000033},
                {"8:18", 69000034},
                {"9b:5", 69000035},
                {"9:22", 69000036},
                {"10:27", 69000037},
                {"12c:7", 69000038},
                {"12d:44", 69000039},
                {"end_3c:13", 69000040},

                // 3A
                {"s2:18", 69000042},
                {"s2:6", 69000043},
                {"00-a:5", 69000044},
                {"00-b:42", 69000045},
                {"s3:2", 69000046},
                {"04-b:14", 69000047},
                {"06-a:7", 69000048},
                {"06-b:14", 69000049},
                {"05-c:2", 69000050},
                {"06-c:3", 69000051},
                {"07-b:4", 69000052},
                {"12-c:1", 69000053},
                {"11-d:52", 69000054},
                {"13-b:31", 69000055},
                {"13-x:13", 69000056},
                {"12-y:1", 69000057},
                {"10-y:2", 69000058},
                {"08-x:4", 69000059},
                {"06-d:238", 69000060},
                {"04-c:40", 69000061},
                {"03-b:1", 69000062},
                {"03-b:25", 69000063},
                {"roof03:97", 69000065},
                {"roof06:276", 69000066},
                {"roof06:308", 69000067},

                // 4A
                {"a-01x:11", 69000069},
                {"a-02:8", 69000070},
                {"a-03:33", 69000071},
                {"a-04:11", 69000072},
                {"a-06:6", 69000073},
                {"a-07:16", 69000074},
                {"a-10:13", 69000075},
                {"a-09:12", 69000076},
                {"b-01:6", 69000078},
                {"b-01:13", 69000079},
                {"b-02:20", 69000080},
                {"b-03:5", 69000081},
                {"b-07:15", 69000082},
                {"b-04:1", 69000083},
                {"b-02:58", 69000084},
                {"b-secb:9", 69000085},
                {"b-08:11", 69000086},
                {"c-01:26", 69000087},
                {"c-00:17", 69000088},
                {"c-05:21", 69000089},
                {"c-06b:43", 69000090},
                {"c-06:35", 69000091},
                {"c-08:28", 69000092},
                {"c-10:55", 69000093},
                {"d-00b:11", 69000094},
                {"d-01:7", 69000095},
                {"d-04:88", 69000096},
                {"d-07:70", 69000097},
                {"d-09:18", 69000098},

                // 5A
                {"a-00x:7", 69000100},
                {"a-01:256", 69000101},
                {"a-01:164", 69000102},
                {"a-04:2", 69000103},
                {"a-03:4", 69000104},
                {"a-02:23", 69000105},
                {"a-05:22", 69000106},
                {"a-07:6", 69000107},
                {"a-06:2", 69000108},
                {"a-14:12", 69000109},
                {"a-11:2", 69000110},
                {"a-15:182", 69000111},
                {"b-18:2", 69000112},
                {"b-01c:85", 69000113},
                {"b-21:99", 69000114},
                {"b-20:183", 69000115},
                {"b-20:72", 69000116},
                {"b-03:24", 69000117},
                {"b-05:23", 69000118},
                {"b-10:4", 69000119},
                {"b-12:3", 69000120},
                {"b-17:14", 69000121},
                {"b-17:10", 69000122},
                {"c-08:112", 69000124},
                {"d-04:122", 69000125},
                {"d-04:16", 69000126},
                {"d-13:157", 69000127},
                {"d-15:217", 69000128},
                {"d-15:335", 69000129},
                {"d-19:533", 69000130},
                {"e-06:56", 69000131},

                //7A
                {"a-02b:61", 69000135},
                {"a-04b:136", 69000136},
                {"a-04b:85", 69000137},
                {"a-05:54", 69000138},
                {"b-02:101", 69000140},
                {"b-02b:102", 69000141},
                {"b-02e:112", 69000142},
                {"b-04:67", 69000143},
                {"b-08:129", 69000144},
                {"b-09:167", 69000145},
                {"c-03b:228", 69000147},
                {"c-05:248", 69000148},
                {"c-06b:281", 69000149},
                {"c-07b:291", 69000150},
                {"c-08:331", 69000151},
                {"c-09:354", 69000152},
                {"d-00:43", 69000154},
                {"d-01c:226", 69000155},
                {"d-01d:282", 69000156},
                {"d-03:383", 69000157},
                {"d-04:388", 69000158},
                {"d-07:484", 69000159},
                {"d-08:527", 69000160},
                {"d-10b:682", 69000161},
                {"e-02:7", 69000164},
                {"e-05:237", 69000165},
                {"e-07:473", 69000166},
                {"e-09:398", 69000167},
                {"e-12:504", 69000168},
                {"e-11:425", 69000169},
                {"e-10:515", 69000170},
                {"e-13:829", 69000171},
                {"f-01:639", 69000173},
                {"f-00:590", 69000174},
                {"f-07:711", 69000175},
                {"f-08b:856", 69000176},
                {"f-08c:759", 69000177},
                {"f-11:1068", 69000178},
                {"f-11:1229", 69000179},
                {"f-11:1238", 69000180},
                {"g-00b:37", 69000182},
                {"g-00b:127", 69000183},
                {"g-00b:114", 69000184},
                {"g-01:66", 69000185},
                {"g-01:279", 69000186},
                {"g-01:342", 69000187},
                {"g-03:1504", 69000188},
            };

            CassetteIDToWorldID = new Dictionary<int, int>
            {
                {1, 69000020},
                {2, 69000031},
                {3, 69000064},
                {4, 69000077},
                {5, 69000123},
                {6, 69000133},
                {7, 69000163}
            };

            HeartIDToWorldID = new Dictionary<string, int>
            {
                {"fc", 69000021},
                {"os", 69000041},
                {"cr", 69000068},
                {"cs", 69000099},
                {"t", 69000132},
                {"tf", 69000134},
                {"ts", 69000189},
            };
        }
    }
}
