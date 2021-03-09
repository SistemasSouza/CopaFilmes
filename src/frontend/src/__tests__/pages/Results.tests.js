import React from 'react';

import { render, wait } from '@testing-library/react';
import AxiosMock from 'axios-mock-adapter';
import api from '../../services/api.services';

import Results from '../../pages/Results';

const apiMock = new AxiosMock(api);

describe('Results', () => {
  it('should be able list movies champions', async () => {
    apiMock.onPost('movies/finish-result').reply(200, [
      {
        "id": "tt4154756",
        "titulo": "Vingadores: Guerra Infinita",
        "ano": 2018,
        "nota": 8.8
      },
      {
        "id": "tt3606756",
        "titulo": "Os Incríveis 2",
        "ano": 2018,
        "nota": 8.5
      },
    ]);

    const { getByText, getByTestId } = render(<Results />);

    await wait(() => {}, {
      timeout: 200,
    });

    expect(getByText('Vingadores: Guerra Infinita')).toBeTruthy();

    expect(getByText('Os Incríveis 2')).toBeTruthy();
  });
})