package org.charles.weilog.service;

import org.charles.weilog.domain.Option;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface OptionService {
    Option insert(Option entity);

    void delete(Long id);

    Option update(Option entity);

    Option query(Long id);

    List<Option> query(String title, int pageIndex, int pageSize);

    List<Option> query(int pageIndex, int pageSize);
}