var fs = require('fs')
var data = require('./myjsonfile.json');

var array2=[]

for (var j = 0; j < data.length; j++) {
              data[j].ObjectData = {
                "ParentId": "",
                ObjectId: data[j].ObjectId,
                "ChartURL": "",
                "Discriptor": data[j].ObjectId,
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
                        "Value": data[j].division
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
                Information: [
                  {
                    "Key": "ne ip",
                    "Language": "",
                    "Value": data[j]["ne ip"],
                  },
                  {
                    "Key": "port description",
                    "Language": "",
                    "Value": data[j]["port description"],
                  }
                ],
                "EmployeeInfo": []
              }
              delete data[j].ObjectId
              delete data[j]["division"]
              delete data[j]["ne ip"]
              delete data[j]["port description"]
            }

let json = JSON.stringify(data);
fs.writeFile('coldserve.json', json, function (err){
    if(err) console.log(`error!::${err}`);
});