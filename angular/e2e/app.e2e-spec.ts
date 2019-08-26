import { AkaratakTemplatePage } from './app.po';

describe('Akaratak App', function() {
  let page: AkaratakTemplatePage;

  beforeEach(() => {
    page = new AkaratakTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
