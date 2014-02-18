bin\debug\googleanalyticsqueryer ^
--viewid "ga:75717800", ^
--startdate "2013-09-25", ^
--enddate "2013-09-25", ^
--metrics "ga:visits,ga:timeOnSite", ^
--dimensions "ga:hostName,ga:customVarValue1,ga:customVarValue2,ga:customVarValue3,ga:city,ga:region,ga:country", ^
--outputpath "c:\junk\Session_Scrub.txt"

bin\debug\googleanalyticsqueryer ^
--viewid "ga:75717800", ^
--startdate "2013-09-25", ^
--enddate "2013-09-25", ^
--metrics "ga:visits", ^
--dimensions "ga:hostName,ga:customVarValue1,ga:referralPath,ga:keyword", ^
--outputpath "c:\junk\Session_Scrub2.txt"


bin\debug\googleanalyticsqueryer ^
--viewid "ga:75717800", ^
--startdate "2013-09-25", ^
--enddate "2013-09-25", ^
--metrics "ga:pageViews", ^
--dimensions "ga:hostName,ga:customVarValue1,ga:pagePath,ga:date,ga:hour", ^
--outputpath "c:\junk\Page_Scrub.txt"


bin\debug\googleanalyticsqueryer ^
--viewid "ga:75717800", ^
--startdate "2013-09-25", ^
--enddate "2013-09-25", ^
--metrics "ga:totalEvents", ^
--dimensions "ga:hostName,ga:customVarValue1,ga:pagePath,ga:eventCategory,ga:eventAction,ga:eventLabel", ^
--outputpath "c:\junk\PageEvent_Scrub.txt"
User::A_EndDate,User::A_StartDate
User::A_UseCustomDates

