$(document).ready(function(){
    
    /*Initialize the SDK
      Needs to be included in the html
      Get your key from Azure dashboard -> bottom nav -> manage keys
    */
    var client = new WindowsAzure.MobileServiceClient(
    "https://rajmymobileservice.azure-mobile.net/",
    "EvsRuOdBtAMTjeqhaJjsnJCfYukXAO58"
    );

    /* Let's get high scores */
    getHighScores();

    function getHighScores(){
        $('.results').empty();// empty this
        /* Get results from table named highscore, order by descending on score column, only return 10*/
        client.getTable('tblrajMyMobileService').orderByDescending("score").take(10).read().done(function(results){
            var len = results.length;
            for(var i=0;i<len;i++){
                var data = results[i];
                if(!data.isDeleted)
                $("<li>"+data.id + "--" +data.user_name+":"+data.score+"</li>").appendTo('.results');
            }
        })
    }

    $("#remove").on("click", function() {
        var item = client.getTable('tblrajMyMobileService').orderByDescending("score").take(2).read({
            success: function (item) {
                alert(item.id)
            del('25DDE30D-105F-4609-92E4-56D7D82E7444');

            //item.isDeleted = true;
            //client.getTable('tblrajMyMobileService').update(item, { success: function () { alert('deleted') } });

        }
        });
        delx('25DDE30D-105F-4609-92E4-56D7D82E7444');
    } );

    function delx(id) {
        var table = client.getTable('tblrajMyMobileService');
        table.orderByDescending("isDeleted").read().done(function (items) {

            var item = items[0];

            alert(item.id);

                        item.isDeleted = false;
                        table.update(item, {
                            success: function () {
                                //request.respond(statusCodes.OK, item);
                            }
                        });
                        getHighScores();


        });
        //    ({
        //    success: function (items) {
        //        if (items.length === 0) {
        //            //request.respond(statusCodes.NOT_FOUND);
        //        } else {
        //            var item = items[0];
        //            item.isDeleted = true;
        //            table.update(item, {
        //                success: function () {
        //                    //request.respond(statusCodes.OK, item);
        //                }
        //            });
        //        }
        //    }
        //});
    }


    function del(id) {
        var table = client.getTable('tblrajMyMobileService');
        table.where({ id: id }).read({
            success: function (items) {
                if (items.length === 0) {
                    //request.respond(statusCodes.NOT_FOUND);
                } else {
                    var item = items[0];
                    item.isDeleted = true;
                    table.update(item, {
                        success: function () {
                            //request.respond(statusCodes.OK, item);
                        }
                    });
                }
            }
        });
    }


    /*Submitting the form, will insert the data, and then refresh it again */
   $( "form" ).on( "submit", function( event ) {
     event.preventDefault();
        var obj={'user_name':$('#user_name').val(),
                 'score':$('#score').val()
             };
        client.getTable("tblrajMyMobileService").insert(obj).done(function (result) {
            getHighScores();
        });

    });
})



/* Basic Rest API - no sdk
 xhr = new XMLHttpRequest();
  function restGet(){
     $.ajax({
    url: ' https://gamingleaderboard.azure-mobile.net/tables/highscore',
    type: 'GET',
    datatype: 'json',
    data:{'$top':'3'},
    success: function(data) { 
        var len = data.length;
        
        for(var i=0;i<len;i++)
        {
           console.log(data[i]);
        }
        
     },
    error: function() { alert('Failed!'); },
    beforeSend: setHeader       
  });   
  }

  function restPost(){
     $.ajax({
    url: ' https://gamingleaderboard.azure-mobile.net/tables/highscore',
    type: 'POST',
    datatype: 'json',
    data:{'user_name':'Mary','score':'333'},
    success: function(data) { 
        var len = data.length;
        console.log("stacey is done")
        for(var i=0;i<len;i++)
        {
        //  $("<p>"+data[i].user_name+":"+data[i].score+"</p>").appendTo('body p');
        }
        
     },
    error: function() { alert('Failed!'); },
    beforeSend: setHeader       
  });   
  }



function setHeader(xhr) {

  xhr.setRequestHeader('X-ZUMO-APPLICATION', 'lsNjRPdjvoigzfsyAePFnMcsLKraFJ21');

}
*/

