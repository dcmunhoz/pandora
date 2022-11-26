export function generateId() {
  function random() {
    return Math.pow(Math.ceil(Math.random() * 10) * Math.floor(Math.random() * 10), 2);
  }

  return random() + '-' + random() + '-' + random() + '-' + random() + '-' + random();
}
