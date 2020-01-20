using RestSharp;
using System;
using System.Collections.Generic;
using Utils;

namespace Petstore.BL
{
    public class PetBL
    {

        public List<Petstore.ET.PetET> findByStatus(string endpoint)
        {

            #region test

            string data = @"
            [
            {
                'id': 9216678377732775206,
        'category': {
                'id': 1,
            'name': 'Wolf'
        },
        'name': 'my doggie',
        'photoUrls': [],
        'tags': [
            {
                'id': 0,
                'name': 'cute'
            }
        ],
        'status': 'available'
    },
    {
        'id': 9216678377732775211,
        'category': {
            'id': 0,
            'name': 'string'
        },
        'name': 'doggie',
        'photoUrls': [
            'string'
        ],
        'tags': [
            {
                'id': 0,
                'name': 'string'
            }
        ],
        'status': 'available'
    },
    {
        'id': 9216678377732775218,
        'category': {
            'id': 0,
            'name': 'string'
        },
        'name': 'doggie',
        'photoUrls': [
            'string'
        ],
        'tags': [
            {
                'id': 0,
                'name': 'string'
            }
        ],
        'status': 'available'
    },
    {
        'id': 9216678377732775227,
        'category': {
            'id': 0,
            'name': 'string'
        },
        'name': 'doggie',
        'photoUrls': [
            'string'
        ],
        'tags': [
            {
                'id': 0,
                'name': 'string'
            }
        ],
        'status': 'available'
    },
    {
        'id': 9216678377732775228,
        'category': {
            'id': 0,
            'name': 'string'
        },
        'name': 'doggie',
        'photoUrls': [
            'string'
        ],
        'tags': [
            {
                'id': 0,
                'name': 'string'
            }
        ],
        'status': 'available'
    },
    {
        'id': 9216678377732775229,
        'category': {
            'id': 0,
            'name': 'string'
        },
        'name': 'doggie',
        'photoUrls': [
            'string'
        ],
        'tags': [
            {
                'id': 0,
                'name': 'string'
            }
        ],
        'status': 'available'
    },
    {
        'id': 9216678377732775230,
        'category': {
            'id': 0,
            'name': 'string'
        },
        'name': 'doggie',
        'photoUrls': [
            'string'
        ],
        'tags': [
            {
                'id': 0,
                'name': 'string'
            }
        ],
        'status': 'available'
    },
    {
        'id': 9216678377732775237,
        'name': 'Goot Doggie',
        'photoUrls': [
            'https://media.karousell.com/media/photos/products/2017/09/14/doggi_door_stopper_1505372529_5cdd1eba0'
        ],
        'tags': [],
        'status': 'available'
    },
    {
        'id': 9216678377732775239,
        'name': 'Goot Doggie',
        'photoUrls': [
            'https://media.karousell.com/media/photos/products/2017/09/14/doggi_door_stopper_1505372529_5cdd1eba0'
        ],
        'tags': [],
        'status': 'available'
    },
    {
        'id': 9216678377732775243,
        'name': 'Goot Doggie',
        'photoUrls': [
            'https://media.karousell.com/media/photos/products/2017/09/14/doggi_door_stopper_1505372529_5cdd1eba0'
        ],
        'tags': [],
        'status': 'available'
    },
    {
        'id': 9216678377732775245,
        'name': 'Goot Doggie',
        'photoUrls': [
            'https://media.karousell.com/media/photos/products/2017/09/14/doggi_door_stopper_1505372529_5cdd1eba0'
        ],
        'tags': [],
        'status': 'available'
    },
    {
        'id': 9216678377732775246,
        'category': {
            'id': 0,
            'name': 'string'
        },
        'name': 'doggie',
        'photoUrls': [
            'string'
        ],
        'tags': [
            {
                'id': 0,
                'name': 'string'
            }
        ],
        'status': 'available'
    },
    {
        'id': 9216678377732775247,
        'category': {
            'id': 0,
            'name': 'string'
        },
        'name': 'doggie',
        'photoUrls': [
            'string'
        ],
        'tags': [
            {
                'id': 0,
                'name': 'string'
            }
        ],
        'status': 'available'
    }
]
";

            List<Petstore.ET.PetET> petET_list = new List<ET.PetET>();

            return petET_list.ToJsonDeserialize(data);

            #endregion

            //IRestResponse restResponse = Utils.Extensions.RestRequest(endpoint, RestSharp.Method.GET);

            //List<Petstore.ET.PetET> petET_list = new List<ET.PetET>();

            //return petET_list.ToJsonDeserialize(restResponse.Content);

        }

        public void delete(string endpoint, Dictionary<string, string> apiKey)
        {
            Utils.Extensions.RestRequest(endpoint, RestSharp.Method.DELETE, apiKey);
        }

        public ET.PetET findById(string endpoint)
        {
            var currentPetData = Utils.Extensions.RestRequest(endpoint, RestSharp.Method.GET);

            ET.PetET petET = new ET.PetET();

            petET = petET.ToJsonDeserialize(currentPetData.Content);

            return petET;
        }

        /// <summary>
        /// Update Name & Status 
        /// </summary>
        /// <param name="endpoint"></param>
        /// <param name="petET"></param>
        public void update(string endpoint, ET.PetET petET, Dictionary<string, string> apiKey)
        {   
            Utils.Extensions.RestRequest(endpoint,
                RestSharp.Method.POST,
                apiKey,
                "application/x-www-form-urlencoded",
                $"petId%20={petET.id}&name={petET.name}&status={petET.status}&undefined=");
        }

        public ET.PetET addNew(string endpoint, ET.PetET petET)
        {          
            IRestResponse response =  Extensions.RestRequest(endpoint, Method.POST, null, "application/json", petET.ToJsonSerialize());
 
            petET = petET.ToJsonDeserialize(response.Content);

            return petET;
        }


    }
}
