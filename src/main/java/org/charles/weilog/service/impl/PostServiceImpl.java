package org.charles.weilog.service.impl;

import org.charles.weilog.domain.Posts;
import org.charles.weilog.service.PostService;
import org.springframework.data.domain.Page;
import org.springframework.data.domain.Pageable;
import org.springframework.data.domain.Sort;
import org.springframework.stereotype.Service;

import java.util.Iterator;
import java.util.List;
import java.util.function.Function;

@Service
public class PostServiceImpl implements PostService {
    @Override
    public Page<Posts> listPost(Pageable pageable) {
        return new Page<Posts>() {
            @Override
            public int getTotalPages() {
                return 0;
            }

            @Override
            public long getTotalElements() {
                return 0;
            }

            @Override
            public <U> Page<U> map(Function<? super Posts, ? extends U> function) {
                return null;
            }

            @Override
            public int getNumber() {
                return 0;
            }

            @Override
            public int getSize() {
                return 0;
            }

            @Override
            public int getNumberOfElements() {
                return 0;
            }

            @Override
            public List<Posts> getContent() {
                return null;
            }

            @Override
            public boolean hasContent() {
                return false;
            }

            @Override
            public Sort getSort() {
                return null;
            }

            @Override
            public boolean isFirst() {
                return false;
            }

            @Override
            public boolean isLast() {
                return false;
            }

            @Override
            public boolean hasNext() {
                return false;
            }

            @Override
            public boolean hasPrevious() {
                return false;
            }

            @Override
            public Pageable nextPageable() {
                return null;
            }

            @Override
            public Pageable previousPageable() {
                return null;
            }

            @Override
            public Iterator<Posts> iterator() {
                return null;
            }
        };
    }

    @Override
    public Page<Posts> listPost(Pageable pageable, String query) {
        return null;
    }

    @Override
    public boolean add(Posts tag) {
        return false;
    }

    @Override
    public boolean remove(Long id) {
        return false;
    }

    @Override
    public boolean update(Posts tag) {
        return false;
    }

    @Override
    public Posts query(Long id) {
        return null;
    }

    @Override
    public List<Posts> query(String title, int pageIndex, int pageSize) {
        return null;
    }

    @Override
    public List<Posts> query(int pageIndex, int pageSize) {
        return null;
    }
}
