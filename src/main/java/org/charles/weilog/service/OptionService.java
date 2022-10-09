package org.charles.weilog.service;

import org.charles.weilog.domain.Option;
import org.springframework.stereotype.Service;

import java.util.List;

@Service
public interface OptionService {
    boolean add(Option option);

    boolean remove(Long id);

    boolean update(Option option);

    Option query(Long id);

    List<Option> query(String title, int pageIndex, int pageSize);

    List<Option> query(int pageIndex, int pageSize);
}