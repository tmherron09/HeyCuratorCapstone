const gulp = require('gulp');
const postcss = require('gulp-postcss');
const purgecss = require('gulp-purgecss');
const sourcemaps = require('gulp-sourcemaps');
const cleanCSS = require('gulp-clean-css');

gulp.task('css:prod', () => {


    return gulp.src('./Styles/site.css')
        .pipe(sourcemaps.init())
        .pipe(postcss([
            require('precss'),
            require('tailwindcss'),
            require('autoprefixer')
        ]))
        .pipe(purgecss({
            content: ['**/*.html', '**/*.razor', '**/*.cshtml', 'Views/**/*.cshtml', 'Views/Shared/_*.cshtml'],
            defaultExtractor: content => content.match(/[^<>"'`\s]*[^<>"'`\s:]/g) || []
        }))
        .pipe(cleanCSS({ level: 2 }))
        .pipe(sourcemaps.write('.'))
        .pipe(gulp.dest('./wwwroot/css/'));
});

gulp.task('css:dev', () => {
    return gulp.src('./Styles/site.css')
        .pipe(sourcemaps.init())
        .pipe(postcss([
            require('precss'),
            require('tailwindcss'),
            require('autoprefixer')
        ]))
        .pipe(gulp.dest('./wwwroot/css/'));
});
