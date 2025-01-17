import { EnilsonSolutionTemplatePage } from './app.po';

describe('EnilsonSolution App', function() {
  let page: EnilsonSolutionTemplatePage;

  beforeEach(() => {
    page = new EnilsonSolutionTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
