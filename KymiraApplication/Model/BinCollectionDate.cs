﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace KymiraApplication.Model
{
   public class BinCollectionDate
    {
        [Required]
      //  [RegularExpression(@"^(?<address1>(?>\d{1,6}(?>\ 1\/[234])?( (N(orth)?|S(outh)?)? ?(E(ast)?|W(est)?))?((?> \d+ ?(th|rd|st|nd))|(?> [A-Z](?>[a-z])+)+) (?>(?i)THROUGHWAY|TRAFFICWAY|CROSSROADS|EXPRESSWAY|BOULEVARD|CROSSROAD|EXTENSION|JUNCTIONS|MOUNTAINS|STRAVENUE|UNDERPASS|CAUSEWAY|CRESCENT|CROSSING|JUNCTION|MOTORWAY|MOUNTAIN|OVERPASS|PARKWAYS|TURNPIKE|VILLIAGE|VILLAGES|CENTERS|CIRCLES|COMMONS|CORNERS|ESTATES|EXPRESS|FORESTS|FREEWAY|GARDENS|GATEWAY|HARBORS|HIGHWAY|HOLLOWS|ISLANDS|JUNCTON|LANDING|MEADOWS|MOUNTIN|ORCHARD|PARKWAY|PASSAGE|PRAIRIE|RANCHES|SPRINGS|SQUARES|STATION|STRAVEN|STRVNUE|STREETS|TERRACE|TRAILER|TUNNELS|VALLEYS|VIADUCT|VILLAGE|ALLEE|ARCADE|AVENUE|BLUFFS|BOTTOM|BRANCH|BRIDGE|BROOKS|BYPASS|CANYON|CAUSWA|CENTER|CENTRE|CIRCLE|CLIFFS|COMMON|CORNER|COURSE|COURTS|CRSENT|CRSSNG|DIVIDE|DRIVES|ESTATE|EXTNSN|FIELDS|FOREST|FORGES|FREEWY|GARDEN|GATEWY|GATWAY|GREENS|GROVES|HARBOR|HIGHWY|HOLLOW|ISLAND|ISLNDS|JCTION|JUNCTN|KNOLLS|LIGHTS|MANORS|MEADOW|MEDOWS|MNTAIN|ORCHRD|PARKWY|PLAINS|POINTS|RADIAL|RADIEL|RAPIDS|RIDGES|SHOALS|SHOARS|SHORES|SKYWAY|SPRING|SPRNGS|SQUARE|STRAVN|STREAM|STREME|STREET|SUMITT|SUMMIT|TRACES|TRACKS|TRAILS|TUNNEL|TURNPK|UNIONS|VALLEY|VIADCT|VILLAG|ALLEE|ALLEY|ANNEX|AVENU|AVNUE|BAYOO|BAYOU|BEACH|BLUFF|BOTTM|BOULV|BRNCH|BRDGE|BROOK|BURGS|BYPAS|CANYN|CENTR|CNTER|CIRCL|CRCLE|CLIFF|COURT|COVES|CREEK|CRSNT|CREST|CURVE|DRIVE|FALLS|FERRY|FIELD|FLATS|FORDS|FORGE|FORKS|FRWAY|GARDN|GRDEN|GRDNS|GTWAY|GLENS|GREEN|GROVE|HARBR|HRBOR|HAVEN|HIWAY|HILLS|HOLWS|ISLND|ISLES|JCTNS|KNOLL|LAKES|LNDNG|LIGHT|LOCKS|LODGE|LOOPS|MANOR|MILLS|MISSN|MOUNT|MNTNS|PARKS|PKWAY|PKWYS|PATHS|PIKES|PINES|PLAIN|PLAZA|POINT|PORTS|RANCH|RNCHS|RAPID|RIDGE|RIVER|ROADS|ROUTE|SHOAL|SHOAR|SHORE|SPRNG|SPNGS|SPURS|STATN|STRAV|STRVN|SUMIT|TRACE|TRACK|TRAIL|TRLRS|TUNEL|TUNLS|TUNNL|TRNPK|UNION|VALLY|VIEWS|VILLG|VILLE|VISTA|WALKS|WELLS|ALLY|ANEX|ANNX|AVEN|BEND|BLUF|BLVD|BOUL|BURG|BYPA|BYPS|CAMP|CNYN|CAPE|CSWY|CENT|CNTR|CIRC|CRCL|CLFS|CLUB|CORS|CRSE|COVE|CRES|XING|DALE|DRIV|ESTS|EXPR|EXPW|EXPY|EXTN|EXTS|FALL|FRRY|FLDS|FLAT|FLTS|FORD|FRST|FORG|FORK|FRKS|FORT|FRWY|GRDN|GDNS|GTWY|GLEN|GROV|HARB|HIWY|HWAY|HILL|HLLW|HOLW|INLT|ISLE|JCTN|JCTS|KEYS|KNOL|KNLS|LAKE|LAND|LNDG|LANE|LOAF|LOCK|LCKS|LDGE|LODG|LOOP|MALL|MNRS|MDWS|MEWS|MILL|MSSN|MNTN|MTIN|NECK|ORCH|OVAL|PARK|PKWY|PASS|PATH|PIKE|PINE|PNES|PLNS|PLZA|PORT|PRTS|RADL|RAMP|RNCH|RPDS|REST|RDGE|RDGS|RIVR|ROAD|SHLS|SHRS|SPNG|SPGS|SPUR|SQRE|SQRS|STRA|STRM|STRT|TERR|TRCE|TRAK|TRKS|TRLS|TRLR|TUNL|VLLY|VLYS|VDCT|VIEW|VILL|VLGS|VIST|VSTA|WALK|WALL|WAYS|WELL|ALY|ANX|ARC|AVE|AVN|BCH|BND|BLF|BOT|BTM|BRG|BRK|BYP|CMP|CPE|CEN|CTR|CIR|CLF|CLB|COR|CTS|CRK|DAM|DIV|DVD|DRV|EST|EXP|EXT|FLS|FRY|FLD|FLT|FRD|FRG|FRK|FRT|FWY|GLN|GRN|GRV|HBR|HVN|HTS|HWY|HLS|ISS|JCT|KEY|KYS|KNL|LKS|LGT|LCK|LDG|MNR|MDW|MNT|MTN|NCK|OVL|PRK|PKY|PLN|PLZ|PTS|PRT|PRR|RAD|RPD|RST|RDG|RIV|RVR|RDS|ROW|RUE|RUN|SHL|SHR|SPG|SQR|SQU|STA|STN|STR|SMT|TER|TRK|TRL|VLY|VIA|VWS|VLG|VIS|VST|WAY|WLS|AV|BR|CP|CT|CV|DL|DM|DV|DR|FT|HT|HL|IS|KY|LK|LN|LF|MT|PL|PT|PR|RD|SQ|ST|UN|VW|VL|WY))( (N(orth)?|S(outh)?)? ?(E(ast)?|W(est)?)?)?)$"),Error]
        public string Address { get; set; }


        public DateTime collectionDate { get; set; }
    }
}