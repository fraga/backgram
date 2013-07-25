backgram.instagram = {
  client_id: '5c66b3716ea04b598ff6639ed7f09784',
  redirect_uri: backgram.base_uri + 'Auth/RedirectUri',
  base_oauth_uri: 'https://instagram.com/oauth/authorize/',
  base_api_uri: 'https://api.instagram.com/v1/',
  
  getOAuthUri: function() {
    return (this.base_oauth_uri + '?client_id='+this.client_id+'&redirect_uri='+this.redirect_uri+'&response_type=code&scope=basic');
  },
  getAccessToken: function () {
    return $.cookie('access_token');
  },
  getError: function() {
    return { 
      error_code: backgram.tools.getUriParameter('error'),
      error_reason: backgram.tools.getUriParameter('error_reason'),
      error_description: backgram.tools.getUriParameter('error_description'),
    };
  },

  photo: {
      getRecents: function (callback, settings) {
          var that = this;
          $.ajax({
              url: backgram.instagram.base_api_uri + 'users/self/media/recent/',
              data: {
                  access_token: backgram.instagram.getAccessToken(),
                  max_id: (settings && settings.maxId) ? settings.maxId : '',
                  count: 20
              },
              dataType: "jsonp",
              jsonpCallback: callback
          });
      }
  }
};