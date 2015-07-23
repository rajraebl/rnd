(function(){
  
  var servicex = function($http)  {
    var getUsers = function()    {
      return $http.get("https://api.github.com/users").then(function(response){
        //console.log(JSON.stringify(response));
        console.log('got response')
        return response.data;
        
      },function(er){console.log(er)});
    }
    
    return {
      getUsers:getUsers
    };
    
  }
  
  
  
  var module = angular.module('myModule');
  module.factory("servicex",servicex);
}());