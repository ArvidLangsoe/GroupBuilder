const path = require('path');

module.exports = {
    outputDir: 'wwwroot',
    baseUrl: "/",
    pages: {
        index: {
            entry: 'clientapp/src/main.js'
        }
    },
    chainWebpack: config => {
        // aspnet uses the other hmr so remove this one
        config.plugins.delete('hmr');
    }
}