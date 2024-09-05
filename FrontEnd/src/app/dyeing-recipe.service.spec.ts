import { TestBed } from '@angular/core/testing';

import { DyeingRecipeService } from './dyeing-recipe.service';

describe('DyeingRecipeService', () => {
  let service: DyeingRecipeService;

  beforeEach(() => {
    TestBed.configureTestingModule({});
    service = TestBed.inject(DyeingRecipeService);
  });

  it('should be created', () => {
    expect(service).toBeTruthy();
  });
});
