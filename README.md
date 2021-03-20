# PhotoExif
a couple of Windows desktop apps to help map out a folder of GPS's tagged photos into a KMZ file<br />
inspired by PhotoKML (http://www.visualtravelguide.com/) but it didnt do exactly what I wanted so wrote my own version.<br />
<br />
that didnt work out so well as I discovered the camera time had not been updated to match the local time....FixExifTimeStamp is the result. <br />
<br />
It runs through the folder list comparing Exif datetaken with the GPS date, adjusted for local time based upon the Lat/Long <br />
Unlike other exif updaters i found, this one allows for different corrections for different cameras.<br />
<br />
Relies heavily on the ExifLibrary GIT project by Ozgur Ozcitak.  <br />It is available as a nuget but I dodnt want the .NetStd libraries, so have included it as source for .net4.7.2<br />
NuGet:  <br />
    DotNetZip  (Henrik/Dino Chiesa)<br />
    GeoTimeZone (Matt Johnson-Pint,Simon Bartlett)<br />
    TimeZoneConvertor   (Matt Johnson-Pint)<br />
   <br />
Thumbnail based on code from c-sharpcorner.   (ManojKalla)<br />
