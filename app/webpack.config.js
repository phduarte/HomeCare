const webpack = require('webpack');
const path = require('path');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const MiniCssExtractPlugin = require("mini-css-extract-plugin");


plugins =  [
    new HtmlWebpackPlugin({
        filename: 'index.html',
        template: path.join(__dirname, 'src/index.html')
    }),
    new MiniCssExtractPlugin(),        
];

// if (process.env.NODE_ENV === 'production') {
//     plugins.push(new webpack.DefinePlugin({
//         "process.env": { 
//             NODE_ENV: JSON.stringify(process.env.NODE_ENV)
//         }
//     }));
//     plugins.push(new webpack.optimize.UglifyJsPlugin());
// }

module.exports = {
    
    entry: path.join(__dirname, 'src/index.jsx'),  
    output: {
        path: path.join(__dirname, 'dist'),
        filename: 'bundle.js'
    },
    resolve:{
        extensions: [".js", ".jsx"]
    },
    plugins: plugins,
    module:{
        rules: [
            {
                test: /\.(js|jsx)$/,
                exclude: /(node_modules|bower_components)/,
                include: path.join(__dirname, 'src'),
                use: [
                {
                    loader: 'babel-loader',
                    options: {
                        presets: ["@babel/preset-env", "@babel/preset-react"]
                    }
                }
                ]
            },
            {
                test: /\.(jpe?g|ico|png|gif|svg|jpg)$/i,
                loader: 'file-loader',
                options: {
                  name: '[path][name].[ext]',
                },
            },
            {
                test: /\.css$/i,                
                // use: [MiniCssExtractPlugin.loader, "css-loader"],
                use: [MiniCssExtractPlugin.loader, { loader: 'css-loader', options: { url: false, sourceMap: true } }],
              }
        ]
    },
    devServer: {
        static: {
            directory: path.join(__dirname, 'public'),
          },        
        compress: true,
        hot: true,
        port: 9000
      },   
}