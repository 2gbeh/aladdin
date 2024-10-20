export class AppHelper {
  static get ts() {
    return Date.now();
  }

  static get dt() {
    return new Date().toJSON();
  }

  static otp = (from = 10000, to = 99999) =>
    Math.floor(Math.random() * (to - from + 1)) + from;
}
