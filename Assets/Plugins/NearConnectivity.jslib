mergeInto(LibraryManager.library, {

  Connect: function () {
    connectwallet();
  },

  Disconnect: function () {
    disconnectwallet();
  },

  Getnfts: function () {
    getNFT();
  }

});