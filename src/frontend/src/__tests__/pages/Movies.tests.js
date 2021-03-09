import React from 'react';

import { render, fireEvent, wait, waitForElement } from '@testing-library/react';

import AxiosMock from 'axios-mock-adapter';
import api from '../../services/api.services';

import Movies from '../../pages/Movies';

const apiMock = new AxiosMock(api);

const mockedHistoryPush = jest.fn()

jest.mock('react-router-dom', () => {
  return {
    ...jest.requireActual('react-router-dom'),
    useHistory: () => ({
      push: mockedHistoryPush,
    }),
  }
})

jest.spyOn(window, 'alert').mockImplementation(() => { })

describe('Movies', () => {
  it('should be able list all movies from api', async () => {
    apiMock.onGet('/movies/get-all').reply(200, [
      {
        "id": "tt3606756",
        "titulo": "Os Incríveis 2",
        "ano": 2018,
        "nota": 8.5
      },
      {
        "id": "tt4881806",
        "titulo": "Jurassic World: Reino Ameaçado",
        "ano": 2018,
        "nota": 6.7
      },
      {
        "id": "tt5164214",
        "titulo": "Oito Mulheres e um Segredo",
        "ano": 2018,
        "nota": 6.3
      },
    ]);

    const { getByText, getByTestId } = render(<Movies />);

    await wait(() => expect(getByText('Os Incríveis 2')).toBeTruthy(), {
      timeout: 200,
    });

    expect(getByText('Os Incríveis 2')).toBeTruthy();
    expect(getByTestId('tt3606756'))

    expect(getByText('Jurassic World: Reino Ameaçado')).toBeTruthy();
    expect(getByTestId('tt4881806'))

    expect(getByText('Oito Mulheres e um Segredo')).toBeTruthy();
    expect(getByTestId('tt5164214'))
  });

  it('Should be select/deselect a movie in list', async () => {
    apiMock.onGet('/movies/get-all').reply(200, [
      {
        "id": "tt3606756",
        "titulo": "Os Incríveis 2",
        "ano": 2018,
        "nota": 8.5
      }
    ]);
    const { getByText, getByTestId } = render(<Movies />);

    await wait(() => expect(getByText('Os Incríveis 2')).toBeTruthy(), {
      timeout: 200,
    });

    expect(getByText('Os Incríveis 2')).toBeTruthy();
    expect(getByTestId('tt3606756'));

    const inputCheckboxNode = await waitForElement(() => getByTestId('tt3606756'));

    fireEvent.change(inputCheckboxNode, { target: { checked: true } })

    expect(inputCheckboxNode.checked).toEqual(true);

    fireEvent.change(inputCheckboxNode, { target: { checked: false } })

    expect(inputCheckboxNode.checked).toEqual(false);
  });

  it('should be not redirect to page result when quantity selected movies is invalid', async () => {
    const { getByText } = render(<Movies />);
    const buttonNode = await waitForElement(() => getByText('Gerar meu campeonato'));

    fireEvent.click(buttonNode);

    expect(mockedHistoryPush).toHaveBeenCalledTimes(0);
    expect(window.alert).toBeCalledWith('Você deve selecionar apenas 8 filmes para disputar o campeonato');
  });
})