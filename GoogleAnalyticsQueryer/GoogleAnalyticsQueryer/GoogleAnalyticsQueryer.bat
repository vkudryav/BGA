bin\debug\googleanalyticsqueryer ^
--viewid "ga:75717800", ^
--startdate "2013-09-15", ^
--enddate "2013-09-26", ^
--metrics "ga:visits", ^
--dimensions "ga:customVarValue1,ga:latitude,ga:longitude,ga:date,ga:hour,ga:campaign", ^
--outputpath "c:\junk\Ga1.txt"

bin\debug\googleanalyticsqueryer ^
--viewid "ga:75717800", ^
--startdate "2013-09-15", ^
--enddate "2013-09-26", ^
--metrics "ga:visits,ga:timeOnSite", ^
--dimensions "ga:customVarValue1,ga:latitude,ga:longitude,ga:source,ga:referralPath,ga:keyword,ga:hostName", ^
--outputpath "c:\junk\Ga2.txt"

bin\debug\googleanalyticsqueryer ^
--viewid "ga:75717800", ^
--startdate "2013-09-26", ^
--enddate "2013-09-26", ^
--metrics "ga:visits", ^
--dimensions "ga:customVarValue1,ga:latitude,ga:longitude,ga:customVarValue2,ga:customVarValue3,ga:date,ga:hour", ^
--outputpath "c:\junk\Ga3.txt"

bin\debug\googleanalyticsqueryer ^
--viewid "ga:75717800", ^
--startdate "2013-09-26", ^
--enddate "2013-09-26", ^
--metrics "ga:pageViews", ^
--dimensions "ga:customVarValue1,ga:latitude,ga:longitude,ga:hostName,ga:pagePath,ga:date,ga:hour", ^
--outputpath "c:\junk\Ga4.txt"

bin\debug\googleanalyticsqueryer ^
--viewid "ga:75717800", ^
--startdate "2013-09-26", ^
--enddate "2013-09-26", ^
--metrics "ga:totalEvents", ^
--dimensions "ga:customVarValue1,ga:latitude,ga:longitude,ga:pagePath,ga:eventCategory,ga:eventAction,ga:eventLabel", ^
--outputpath "c:\junk\Ga5.txt"

bin\debug\googleanalyticsqueryer ^
--viewid "ga:75717800", ^
--startdate "2013-09-26", ^
--enddate "2013-09-26", ^
--metrics "ga:pageViews", ^
--dimensions "ga:customVarValue1,ga:latitude,ga:longitude,ga:hostName,ga:city,ga:region,ga:country", ^
--outputpath "c:\junk\Ga6.txt"
