const gulp = require('gulp');

gulp.task('css', () => {
    const postcss = require('gulp-postcss');
    const sourcemaps = require('gulp-sourcemaps');
    const cleanCSS = require('gulp-clean-css');

    return gulp.src('./Styles/site.css')
        .pipe(sourcemaps.init())
        .pipe(postcss([
            require('precss'),
            require('tailwindcss'),
            require('autoprefixer')
        ]))
        .pipe(gulp.dest('./wwwroot/css/'));
});