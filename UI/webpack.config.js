const path = require('path');
const webpack = require("webpack");
const CopyWebpackPlugin = require('copy-webpack-plugin');
const HtmlWebpackPlugin = require('html-webpack-plugin');
const fs = require('fs');
const dotenv = require('dotenv');

module.exports = (env) => {
    const currentPath = path.join(__dirname);
    const basePath = currentPath + '/.env';
    const fileEnv = dotenv.config({ path: basePath }).parsed;
    const envKeys = Object.keys(fileEnv).reduce((prev, next) => {
        prev[`process.env.${next}`] = JSON.stringify(fileEnv[next]);
        return prev;
    }, {});

    return {
        mode: 'development',
        entry: './src/app.tsx',
        output: {
            filename: './output.js',
            path: path.resolve(__dirname, 'build')
        },
        resolve: {
            extensions: ['.tsx', '.ts', '.js']
        },
        plugins: [
            new webpack.DefinePlugin(envKeys),
            new HtmlWebpackPlugin({
                title: 'Formula1',
                description: 'Formula1',
                template: 'index.html',
                inject: false,
                minify: {
                    removeComments: true,
                    collapseWhitespace: false
                }
            })
        ],
        module: {
            rules: [
                {
                    test: /\.tsx?$/,
                    use: 'ts-loader',
                    exclude: /node_modules/
                },
                {
                    test: /\.css$/,
                    use: [
                        'style-loader',
                        'css-loader'
                    ]
                },
                {
                    test: /\.[s][ac]ss$/i,
                    use: [
                        'style-loader',
                        'css-loader',
                        'sass-loader'
                    ]
                }
            ]
        },
        devServer: {
            port: 8080,
            historyApiFallback: {
                index: 'index.html'
            }
        }
    }
}