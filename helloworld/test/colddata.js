var fs = require('fs')
var data = require('./test.json');

var array2=[]

for (var j = 0; j < data.length; j++) {
              data[j].ObjectData = {
                "ParentId": "",
                ObjectId: data[j].ObjectData.ObjectId,
                "ChartURL": "",
                "Discriptor": data[j].ObjectData.ObjectId,
                "Status": "",
                "Thumbnail": "",
                "HotdataInfo": [
                    {
                        "Key": "ObjectUnitDescriptor",
                        "Language": "",
                        "Value": ""
                    },
                    {
                        "Key": "ocmsSensorName",
                        "Language": "",
                        "Value": data[j].ObjectData.ObjectId.substring(0, 3)
                    }
                ],
                 "PointControllerInfo": [
                    {
                    "Key": "DisplayValue0",
                    "Language": "",
                    "Value": ""
                    },
                    {
                    "Key": "DisplayValue1",
                    "Language": "",
                    "Value": ""
                    },
                    {
                    "Key": "ControlHref",
                    "Language": "ControlHref",
                    "Value": "No available"
                    }
                ],
                Information: [],
                "EmployeeInfo": []
              }
            }

let json = JSON.stringify(data);
fs.writeFile('coldserve.json', json, function (err){
    if(err) console.log(`error!::${err}`);
});