import { ProductManagementTemplatePage } from './app.po';

describe('ProductManagement App', function() {
  let page: ProductManagementTemplatePage;

  beforeEach(() => {
    page = new ProductManagementTemplatePage();
  });

  it('should display message saying app works', () => {
    page.navigateTo();
    expect(page.getParagraphText()).toEqual('app works!');
  });
});
