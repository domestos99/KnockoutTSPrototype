const path = require('path');


module.exports = {
  mode: 'development',
  entry: {
    default: './src/default.ts',
    about: './src/about.ts'
  },
  devtool: 'source-map', // Generate separate source map files
  devServer: {
    contentBase: './dist',
    overlay: true // Show errors in overlay on the website
  },
  module: {
    rules: [
      {
        test: /\.(js|ts)$/,
        exclude: /node_modules/,
        loader: 'babel-loader'
      },
      {
        test: /\.html$/, // All Knockout.js component HTML templates
        use: 'html-loader' // Adds the component templates to the bundle
      }
    ]
  },
  plugins: [
    
  ],
  resolve: {
    extensions: ['.js', '.ts']
  }
};
