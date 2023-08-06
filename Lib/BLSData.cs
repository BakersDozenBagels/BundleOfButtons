﻿using System;
using System.Collections.ObjectModel;
using System.Linq;

namespace BlueButtonLib
{
    internal class BLSData
    {
        private const string SQUARES = "1230201331020321|1230201303213102|1230210330120321|1230210330210312|1230210303123021|1230210303213012|1230230130120123|1230230101233012|1230310220130321|1230310203212013|1230301221030321|1230301223010123|1230301201232301|1230301203212103|1230302121030312|1230302103122103|1230012323013012|1230012330122301|1230031221033021|1230031230212103|1230032121033012|1230032120133102|1230032131022013|1230032130122103|1203231030210132|1203231001323021|1203213030120321|1203213030210312|1203213003123021|1203213003213012|1203203131200312|1203203103123120|1203312020310312|1203312003122031|1203301221300321|1203301203212130|1203302121300312|1203302123100132|1203302101322310|1203302103122130|1203013223103021|1203013230212310|1203031221303021|1203031220313120|1203031231202031|1203031230212130|1203032121303012|1203032130122130|1320210330120231|1320210302313012|1320201331020231|1320201332010132|1320201301323201|1320201302313102|1320203131020213|1320203102133102|1320301221030231|1320301202312103|1320310220130231|1320310220310213|1320310202132031|1320310202312013|1320320120130132|1320320101322013|1320013220133201|1320013232012013|1320021320313102|1320021331022031|1320023121033012|1320023120133102|1320023131022013|1320023130122103|1302213030210213|1302213002133021|1302201331200231|1302201302313120|1302203131200213|1302203132100123|1302203101233210|1302203102133120|1302321020310123|1302321001232031|1302312020130231|1302312020310213|1302312002132031|1302312002312013|1302302121300213|1302302102132130|1302012320313210|1302012332102031|1302021321303021|1302021320313120|1302021331202031|1302021330212130|1302023120133120|1302023131202013|1023213032010312|1023213003123201|1023231031020231|1023231032010132|1023231001323201|1023231002313102|1023230132100132|1023230101323210|1023310223100231|1023310202312310|1023321023010132|1023321001322301|1023320121300312|1023320123100132|1023320101322310|1023320103122130|1023031221303201|1023031232012130|1023013223103201|1023013223013210|1023013232102301|1023013232012310|1023023123103102|1023023131022310|1032210332100321|1032210303213210|1032231032010123|1032231001233201|1032230131200213|1032230132100123|1032230101233210|1032230102133120|1032312023010213|1032312002132301|1032321021030321|1032321023010123|1032321001232301|1032321003212103|1032320123100123|1032320101232310|1032021323013120|1032021331202301|1032012323103201|1032012323013210|1032012332102301|1032012332012310|1032032121033210|1032032132102103|2130102332010312|2130102303123201|2130120330120321|2130120330210312|2130120303123021|2130120303213012|2130130230210213|2130130202133021|2130320110230312|2130320103121023|2130301212030321|2130301203211203|2130302112030312|2130302113020213|2130302102131302|2130302103121203|2130021313023021|2130021330211302|2130031212033021|2130031210233201|2130031232011023|2130031230211203|2130032112033012|2130032130121203|2103132030120231|2103132002313012|2103123030120321|2103123030210312|2103123003123021|2103123003213012|2103103232100321|2103103203213210|2103321010320321|2103321003211032|2103301212300321|2103301213200231|2103301202311320|2103301203211230|2103302112300312|2103302103121230|2103023113203012|2103023130121320|2103031212303021|2103031230211230|2103032112303012|2103032110323210|2103032132101032|2103032130121230|2310120330210132|2310120301323021|2310102331020231|2310102332010132|2310102301323201|2310102302313102|2310103232010123|2310103201233201|2310302112030132|2310302101321203|2310310210230231|2310310202311023|2310320110230132|2310320110320123|2310320101231032|2310320101321023|2310012310323201|2310012332011032|2310013212033021|2310013210233201|2310013232011023|2310013230211203|2310023110233102|2310023131021023|2301123030120123|2301123001233012|2301102332100132|2301102301323210|2301103231200213|2301103232100123|2301103201233210|2301103202133120|2301321010230132|2301321010320123|2301321001231032|2301321001321023|2301301212300123|2301301201231230|2301312010320213|2301312002131032|2301012312303012|2301012310323210|2301012332101032|2301012330121230|2301013210233210|2301013232101023|2301021310323120|2301021331201032|2013123031020321|2013123003213102|2013132031020231|2013132032010132|2013132001323201|2013132002313102|2013130231200231|2013130202313120|2013312013020231|2013312002311302|2013310212300321|2013310213200231|2013310202311320|2013310203211230|2013320113200132|2013320101321320|2013032112303102|2013032131021230|2013013213203201|2013013232011320|2013023113203102|2013023113023120|2013023131201302|2013023131021320|2031120331200312|2031120303123120|2031132031020213|2031132002133102|2031130231200213|2031130232100123|2031130201233210|2031130202133120|2031312012030312|2031312013020213|2031312002131302|2031312003121203|2031310213200213|2031310202131320|2031321013020123|2031321001231302|2031021313203102|2031021313023120|2031021331201302|2031021331021320|2031031212033120|2031031231201203|2031012313023210|2031012332101302|3120103223010213|3120103202132301|3120120320310312|3120120303122031|3120130220130231|3120130220310213|3120130202132031|3120130202312013|3120230110320213|3120230102131032|3120201313020231|3120201302311302|3120203112030312|3120203113020213|3120203102131302|3120203103121203|3120021313022031|3120021310322301|3120021323011032|3120021320311302|3120023113022013|3120023120131302|3120031212032031|3120031220311203|3102132020130231|3102132020310213|3102132002132031|3102132002312013|3102102323100231|3102102302312310|3102123020130321|3102123003212013|3102231010230231|3102231002311023|3102201312300321|3102201313200231|3102201302311320|3102201303211230|3102203113200213|3102203102131320|3102021313202031|3102021320311320|3102023113202013|3102023110232310|3102023123101023|3102023120131320|3102032112302013|3102032120131230|3210130220310123|3210130201232031|3210102323010132|3210102301322301|3210103221030321|3210103223010123|3210103201232301|3210103203212103|3210203113020123|3210203101231302|3210210310320321|3210210303211032|3210230110230132|3210230110320123|3210230101231032|3210230101321023|3210012313022031|3210012310322301|3210012323011032|3210012320311302|3210013210232301|3210013223011023|3210032110322103|3210032121031032|3201132020130132|3201132001322013|3201102321300312|3201102323100132|3201102301322310|3201102303122130|3201103223100123|3201103201232310|3201231010230132|3201231010320123|3201231001231032|3201231001321023|3201201313200132|3201201301321320|3201213010230312|3201213003121023|3201012310322310|3201012323101032|3201013213202013|3201013210232310|3201013223101023|3201013220131320|3201031210232130|3201031221301023|3012123021030321|3012123023010123|3012123001232301|3012123003212103|3012120321300321|3012120303212130|3012132021030231|3012132002312103|3012213012030321|3012213003211203|3012210312300321|3012210313200231|3012210302311320|3012210303211230|3012230112300123|3012230101231230|3012012312302301|3012012323011230|3012032112302103|3012032112032130|3012032121301203|3012032121031230|3012023113202103|3012023121031320|3021123021030312|3021123003122103|3021120321300312|3021120323100132|3021120301322310|3021120303122130|3021130221300213|3021130202132130|3021213012030312|3021213013020213|3021213002131302|3021213003121203|3021210312300312|3021210303121230|3021231012030132|3021231001321203|3021021313022130|3021021321301302|3021031212302103|3021031212032130|3021031221301203|3021031221031230|3021013212032310|3021013223101203|0123123023013012|0123123030122301|0123103223103201|0123103223013210|0123103232102301|0123103232012310|0123130220313210|0123130232102031|0123231010323201|0123231032011032|0123230112303012|0123230110323210|0123230132101032|0123230130121230|0123203113023210|0123203132101302|0123321013022031|0123321010322301|0123321023011032|0123321020311302|0123320110322310|0123320123101032|0123301212302301|0123301223011230|0132132020133201|0132132032012013|0132102323103201|0132102323013210|0132102332102301|0132102332012310|0132120323103021|0132120330212310|0132231012033021|0132231010233201|0132231032011023|0132231030211203|0132230110233210|0132230132101023|0132201313203201|0132201332011320|0132321010232301|0132321023011023|0132320113202013|0132320110232310|0132320123101023|0132320120131320|0132302112032310|0132302123101203|0213132020313102|0213132031022031|0213130221303021|0213130220313120|0213130231202031|0213130230212130|0213103223013120|0213103231202301|0213213013023021|0213213030211302|0213203113203102|0213203113023120|0213203131201302|0213203131021320|0213230110323120|0213230131201032|0213312013022031|0213312010322301|0213312023011032|0213312020311302|0213310213202031|0213310220311320|0213302113022130|0213302121301302|0231132021033012|0231132020133102|0231132031022013|0231132030122103|0231130220133120|0231130231202013|0231102323103102|0231102331022310|0231231010233102|0231231031021023|0231201313203102|0231201313023120|0231201331201302|0231201331021320|0231210313203012|0231210330121320|0231312013022013|0231312020131302|0231310213202013|0231310210232310|0231310223101023|0231310220131320|0231301213202103|0231301221031320|0312123021033021|0312123030212103|0312120321303021|0312120320313120|0312120331202031|0312120330212130|0312102321303201|0312102332012130|0312213012033021|0312213010233201|0312213032011023|0312213030211203|0312210312303021|0312210330211230|0312203112033120|0312203131201203|0312312012032031|0312312020311203|0312302112302103|0312302112032130|0312302121301203|0312302121031230|0312320110232130|0312320121301023|0321123021033012|0321123020133102|0321123031022013|0321123030122103|0321120321303012|0321120330122130|0321103221033210|0321103232102103|0321213012033012|0321213030121203|0321210312303012|0321210310323210|0321210332101032|0321210330121230|0321201312303102|0321201331021230|0321321010322103|0321321021031032|0321301212302103|0321301212032130|0321301221301203|0321301221031230|0321310212302013|0321310220131230";

        internal static ReadOnlyCollection<BlueLatinSquare> GenerateAllSquares()
        {
            return Array.AsReadOnly(SQUARES.Split('|').Select(s => new BlueLatinSquare(Array.AsReadOnly(s.Select(c => c - '0').ToArray()))).ToArray());
        }
    }
}