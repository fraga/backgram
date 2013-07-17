backgram.tools = {
  getUriParameter: function(name) {
    return this.extractValue(name, location.search);
  },
  getUriAnchor: function(name) {
    return this.extractValue(name, location.hash);
  },
  extractValue: function(name, uri) {
    return decodeURI(
      (RegExp(name + '=' + '(.+?)(&|$)').exec(uri)||[,''])[1]
    );
  }
};