const app = require('app')

describe('App', () => {
  it('should accept valid comma separated input', () => {
    const processSpy = spyOn(process, 'exit');

    spyOnProperty(process, 'argv').and.returnValue(['', '', '1,2,3,4']);

    app();

    expect(processSpy).toHaveBeenCalledWith(0);
  });
});
